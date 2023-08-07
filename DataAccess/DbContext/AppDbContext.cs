using Domain.Entities;

namespace DataAccess.DbContext;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    //DB Sets
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure entity mappings and relationships here
        // Example: modelBuilder.Entity<Customer>().HasKey(c => c.Id);
    }
}