namespace DotGetBackend.Application.Features.Professors.Dtos;

public class ProfessorDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ProfilePicture { get; set; }

    public ICollection<string> Subjects { get; set; }
}