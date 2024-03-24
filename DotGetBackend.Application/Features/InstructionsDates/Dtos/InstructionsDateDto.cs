using DotGetBackend.Domain.Enums;

namespace DotGetBackend.Application.Features.InstructionsDates.Dtos;

public class InstructionsDateDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public InstructionDateStatus Status { get; set; }
    
    public Guid ProfessorId { get; set; }
    public Guid SubjectId { get; set; }
}