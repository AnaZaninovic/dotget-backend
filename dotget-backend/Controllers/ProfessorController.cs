using dotget_backend.Requests;
using DotGetBackend.Application.Features.Professors.Commands;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Application.Features.Professors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotget_backend.Controllers;

public class ProfessorController: ControllerBase
{
    private readonly IMediator _mediator;
    public ProfessorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("/professors")]
    public async Task<ActionResult<ICollection<ProfessorDto>>> GetAllProfessors()
    {
        var query = new GetAllProfessorsQuery();
        var professors = await _mediator.Send(query);

        return Ok(new { professors });
    }
}