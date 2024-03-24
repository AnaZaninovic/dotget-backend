using DotGetBackend.Application.Features.Professors.Dtos;

namespace DotGetBackend.Application.Features.Subjects.Dtos;

public class SubjectDto
{
    public Guid Id { get; set; }
    public String Title {get; set; }
    public String Url {get; set; }
    public String Description {get; set; }
}