using System.Runtime.InteropServices.JavaScript;
using DotGetBackend.Domain.Enums;

namespace DotGetBackend.Domain.Entities;

public class InstructionsDate
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public InstructionDateStatus Status { get; set; }
    
    public Guid ProfessorId { get; set; }
    //public Professor Professor { get; set; } = default!;
    
    public Guid SubjectId { get; set; }
    //public Subject Subject { get; set; } = default!;
    
}