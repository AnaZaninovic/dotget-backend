namespace DotGetBackend.Domain.Entities;

public class Subject
{
    public Guid Id { get; set; }
    public String Title {get; set; }
    public String Url {get; set; }
    public String Description {get; set; }
    
    public ICollection<ProfessorSubject>? ProfessorSubjects { get; set; }
}