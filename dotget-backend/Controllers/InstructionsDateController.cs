using DotGetBackend.Application.Features.InstructionsDates.Commands;
using DotGetBackend.Application.Features.InstructionsDates.Dtos;
using DotGetBackend.Application.Features.InstructionsDates.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotget_backend.Controllers;

[ApiController]
public class InstructionsDateController: ControllerBase
{
    private readonly IMediator _mediator;
    public InstructionsDateController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("/instructions")]
    [Consumes("application/json")]
    public async Task<ActionResult<InstructionsDateDto>> CreateInstructionsDate([FromBody] CreateInstrucitonsDateCommand request)
    {
        var command = new CreateInstrucitonsDateCommand()
        {
            Date = request.Date,
            ProfessorId = request.ProfessorId,
            SubjectId = request.SubjectId,
        };

        var instructionsDate = await _mediator.Send(command);

        return CreatedAtAction(nameof(CreateInstructionsDate), new { }, instructionsDate);
    }
    
    [HttpGet("/instructions")]
    public async Task<ActionResult<IEnumerable<InstructionsDateDto>>> GetAllInstructionsDates()
    {
        var query = new GetAllInstructionsDatesQuery();
        var instructionsDates = await _mediator.Send(query);
        return Ok(instructionsDates);
    }
}