namespace DotGetBackend.Application.Features.Students.Dtos;

public class StudentDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string ProfilePictureUrl { get; set; }
}