using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.DbContext;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    //DB Sets
    public DbSet<User> Users { get; set; }
    public DbSet<Certificate> Certificates { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseAttendance> CourseAttendances { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Session> Sessions { get; set; }
    public DbSet<SessionAttendance> SessionAttendances { get; set; }
    public DbSet<Topic> Topic { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<User>(ConfigureUser);
       modelBuilder.Entity<Certificate>(ConfigureCertificate);
       modelBuilder.Entity<Course>(ConfigureCourse);
       modelBuilder.Entity<Session>(ConfigureSession);
       modelBuilder.Entity<CourseAttendance>(ConfigureCourseAttendence);
       modelBuilder.Entity<Role>(ConfigureRoles);
       modelBuilder.Entity<SessionAttendance>(ConfigureSessionAttendance);
       modelBuilder.Entity<Topic>(ConfigureTopic);
       modelBuilder.Entity<Category>(ConfigureCategory);
    }

    private void ConfigureCategory(EntityTypeBuilder<Category> entity)
    {
        entity.ToTable("t_categories"); 
        
        entity.HasKey(ca => ca.CategoryId);
                
        entity.Property(ca => ca.CategoryId).HasColumnName("id_category").IsRequired();
        entity.Property(ca => ca.CategoryName).HasColumnName("category_name").IsRequired();

        entity.HasMany(ca => ca.Courses)
            .WithOne(c => c.Category)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(ca => ca.Topics)
            .WithOne(t => t.Category)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureTopic(EntityTypeBuilder<Topic> entity)
    {
        entity.ToTable("t_topics"); 
        
        entity.HasKey(t => new {t.CategoryId,t.TopicId});

        entity.Property(t => t.CategoryId).HasColumnName("id_category").IsRequired();
        entity.Property(t => t.TopicId).HasColumnName("id_topic").IsRequired();
        entity.Property(t => t.TopicName).HasColumnName("topic_name").IsRequired();

        entity.HasOne(t => t.Category)
            .WithMany(ca => ca.Topics)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureSessionAttendance(EntityTypeBuilder<SessionAttendance> entity)
    {
        entity.ToTable("t_session_attendances"); 
        
        entity.HasKey(s => new {s.SessionId,s.UserId});
                
        entity.Property(s => s.SessionId).HasColumnName("id_session").IsRequired();
        entity.Property(s => s.UserId).HasColumnName("id_user").IsRequired();

        entity.HasOne(s => s.Session)
            .WithMany(s => s.SessionAttendances)
            .HasForeignKey(s=>s.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        entity.HasOne(s=>s.User)
            .WithMany(u=>u.SessionAttendances)
            .HasForeignKey(s=>s.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureRoles(EntityTypeBuilder<Role> entity)
    {
        entity.ToTable("t_roles");

        entity.HasKey(r => r.RoleId);
                
        entity.Property(r=>r.RoleId).HasColumnName("id_role").IsRequired();
        entity.Property(r=>r.RoleName).HasColumnName("role_name").IsRequired();

        entity.HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    private void ConfigureCourseAttendence(EntityTypeBuilder<CourseAttendance> entity)
    {
        entity.ToTable("t_course_attendances"); 
        
        entity.HasKey(ca => new {ca.CourseId,ca.UserId});
                
        entity.Property(ca => ca.CourseId).HasColumnName("id_course").IsRequired();
        entity.Property(ca => ca.UserId).HasColumnName("id_user").IsRequired();

        entity.HasOne(ca => ca.Course)
            .WithMany(c => c.CourseAttendances)
            .HasForeignKey(ca => ca.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
        
        entity.HasOne(ca => ca.User)
            .WithMany(u => u.CourseAttendances)
            .HasForeignKey(ca => ca.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureSession(EntityTypeBuilder<Session> entity)
    {
        entity.ToTable("t_sessions"); 
        
        entity.HasKey(c => c.SessionId);
                
        entity.Property(c => c.SessionId).HasColumnName("id_session").IsRequired();
        entity.Property(c => c.CourseId).HasColumnName("id_course").IsRequired();
        entity.Property(c => c.Address).HasColumnName("address").IsRequired();
        entity.Property(c => c.SessionDate).HasColumnName("session_date").IsRequired();

        entity.HasOne(s => s.Course)
            .WithMany(c => c.Sessions)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(s => s.SessionAttendances)
            .WithOne(sa => sa.Session)
            .HasForeignKey(sa => sa.SessionId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureCourse(EntityTypeBuilder<Course> entity)
    {
        entity.ToTable("t_courses"); 

        entity.HasKey(c => c.CourseId);
        
        entity.Property(c => c.CourseId).HasColumnName("id_course").IsRequired();
        entity.Property(c => c.Name).HasColumnName("course_name").IsRequired();
        entity.Property(c => c.Description).HasColumnName("course_description").IsRequired();
        entity.Property(c => c.ImagePath).HasColumnName("image_path").IsRequired();
        entity.Property(c => c.CategoryId).HasColumnName("id_category").IsRequired(); 
        
        entity.HasMany(c => c.Sessions)
            .WithOne(s => s.Course)
            .HasForeignKey(s => s.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasMany(c => c.CourseAttendances)
            .WithOne(ca => ca.Course)
            .HasForeignKey(ca => ca.CourseId)
            .OnDelete(DeleteBehavior.Cascade);;

        entity.HasMany(c => c.Certificates)
            .WithOne(crt => crt.Course)
            .HasForeignKey(crt => crt.CourseId)
            .OnDelete(DeleteBehavior.Restrict);;

        // Define the many-to-one relationship with Category using .HasOne()
        entity.HasOne(c => c.Category)
            .WithMany(ca => ca.Courses)
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);;
    }

    private void ConfigureCertificate(EntityTypeBuilder<Certificate> entity)
    {
        entity.ToTable("t_certificates");
        entity.HasKey(e => new { e.CertificateId, e.CourseId });
        
        entity.Property(c => c.CertificateId).HasColumnName("id_certificate").IsRequired();
        entity.Property(c => c.CourseId).HasColumnName("id_course").IsRequired();
        entity.Property(c => c.CompletionDate).HasColumnName("completion_date").IsRequired();
        entity.Property(c => c.UserId).HasColumnName("id_user").IsRequired();

        entity.HasOne(c => c.Course)
            .WithMany(co => co.Certificates)
            .HasForeignKey(c => c.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(c => c.User)
            .WithMany(u => u.Certificates)
            .HasForeignKey(c => c.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    private void ConfigureUser(EntityTypeBuilder<User> entity)
    {
            entity.ToTable("t_users");
            entity.HasKey(e => e.UserId);

            entity.Property(e => e.UserId).HasColumnName("id_user").IsRequired();
            entity.Property(e => e.Email).HasColumnName("email").IsRequired();
            entity.Property(e => e.Password).HasColumnName("password").IsRequired();
            entity.Property(e => e.FirstName).HasColumnName("first_name").IsRequired();
            entity.Property(e => e.LastName).HasColumnName("last_name").IsRequired();
            entity.Property(e => e.RoleId).HasColumnName("id_role").IsRequired();

            entity.HasMany(u => u.CourseAttendances)
                .WithOne(ca => ca.User)
                .HasForeignKey(ca => ca.UserId)
                .OnDelete(DeleteBehavior.Cascade);
           
            entity.HasMany(u => u.SessionAttendances)
                .WithOne(sa => sa.User)
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Cascade);
           
            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(u => u.Certificates)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

    }
}