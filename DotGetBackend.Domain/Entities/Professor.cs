using System.ComponentModel.DataAnnotations;

namespace DotGetBackend.Domain.Entities;

public class Professor
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    
    public string? ProfilePictureUrl { get; set; }
    
    //public string? Subject { get; set; }
    public ICollection<ProfessorSubject>? ProfessorSubjects { get; set; }
}