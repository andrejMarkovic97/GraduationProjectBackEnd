namespace Domain.Entities;

public class Certificate
{
    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public Guid CertificateId { get; set; }
    public DateTime CompletionDate { get; set; }
    public User User { get; set; }
    public Guid UserId { get; set; }
}