namespace DotGetBackend.Application.Features.Students.Dtos;

public class StudentLoginDto
{
    public bool Success { get; set; }
    public string? Token { get; set; }
    public StudentDto? Student { get; set; }
    public string? Message { get; set; }
}