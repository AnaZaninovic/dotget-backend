namespace DotGetBackend.Application.Features.Professors.Dtos;

public class ProfessorLoginDto
{
    public bool Success { get; set; }
    public string? Token { get; set; }
    public ProfessorDto? Professor { get; set; }
    public string? Message { get; set; }
}