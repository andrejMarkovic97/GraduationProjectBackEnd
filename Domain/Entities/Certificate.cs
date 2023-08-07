namespace Domain.Entities;

public class Certificate
{
    public Certificate(Course course, Guid courseId, Guid certificateId, DateTime completionDate)
    {
        Course = course;
        CourseId = courseId;
        CertificateId = certificateId;
        CompletionDate = completionDate;
    }

    public Course Course { get; set; }
    public Guid CourseId { get; set; }
    public Guid CertificateId { get; set; }
    public DateTime CompletionDate { get; set; }
}