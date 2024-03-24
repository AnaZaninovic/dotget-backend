using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Domain.Entities;

namespace DotGetBackend.Application.Features.Subjects.Dtos;

public class SubjectByUrlDto
{
    public bool Success { get; set; }
    public SubjectDto? Subject { get; set; }
    public ICollection<ProfessorDto>? Professors { get; set; }
    public string Message { get; set; }
    
}