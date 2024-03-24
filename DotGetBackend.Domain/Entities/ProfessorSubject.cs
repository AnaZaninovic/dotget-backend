namespace DotGetBackend.Domain.Entities;

public class ProfessorSubject
{
    public Guid Id { get; set; }
    
    public Guid ProfessorId { get; set; }
    public Professor Professor { get; set; } = default!;
    
    public Guid SubjectId { get; set; }
    public Subject Subject { get; set; } = default!;
}