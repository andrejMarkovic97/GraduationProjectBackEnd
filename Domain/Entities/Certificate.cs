namespace Domain.Entities;

public class Certificate
{
    public Certificate(Course course, Guid courseId, Guid certificateId, DateTime completionDate, User user, Guid userId)
    {
        Course = course;
        CourseId = courseId;
        CertificateId = certificateId;
        CompletionDate = completionDate;
        User = user;
        UserId = userId;
    }

    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public Guid CertificateId { get; set; }
    public DateTime CompletionDate { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}