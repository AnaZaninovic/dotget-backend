using dotget_backend.Requests;
using DotGetBackend.Application.Features.Subjects.Commands;
using DotGetBackend.Application.Features.Subjects.Dtos;
using DotGetBackend.Application.Features.Subjects.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotget_backend.Controllers;

[ApiController]
public class SubjectController : ControllerBase
{
    private readonly IMediator _mediator;
    public SubjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/subject")]
    [Consumes("application/json")]
    public async Task<ActionResult<SubjectDto>> CreateSubject([FromBody] CreateSubjectRequest request)
    {
        var command = new CreateSubjectCommand()
        {
            Title = request.Title,
            Url = request.Url,
            Description = request.Description
        };

        var subject = await _mediator.Send(command);

        return CreatedAtAction(nameof(CreateSubject), new { }, subject);
    }
    
    [HttpGet("/subjects")]
    public async Task<ActionResult<ICollection<SubjectDto>>> GetAllSubjects()
    {
        var query = new GetAllSubjectsQuery();
        var subjects = await _mediator.Send(query);

        return Ok(new { subjects });
    }
    
    [HttpGet("/subject/{url}")]
    public async Task<ActionResult<SubjectByUrlDto>> GetSubjectByUrl(string url)
    {
        var query = new GetSubjectByUrlQuery()
        {
            Url = url
        };
        
        var subject = await _mediator.Send(query);

        return Ok(subject);
    }
}