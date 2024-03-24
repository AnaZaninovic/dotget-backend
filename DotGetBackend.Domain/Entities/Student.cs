namespace DotGetBackend.Domain.Entities;

public class Student
{
    public Guid Id { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public string? ProfilePictureUrl { get; set; }
}