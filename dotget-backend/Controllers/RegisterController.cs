using dotget_backend.Requests;
using DotGetBackend.Application.Features.Professors.Commands;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Application.Features.Students.Commands;
using DotGetBackend.Application.Features.Students.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dotget_backend.Controllers;

[ApiController]
public class RegisterController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegisterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/register/student")]
    
    public async Task<ActionResult<StudentDto>> RegisterStudent([FromForm] CreateStudentRequest request)
    {
        var command = new CreateStudentCommand()
        {
            Email = request.Email,
            Password = request.Password,
            ConfirmPassword = request.ConfirmPassword,
            Name = request.Name,
            Surname = request.Surname,
            ProfilePicture = request.ProfilePicture?.OpenReadStream()
        };

        var student = await _mediator.Send(command);

        return CreatedAtAction(nameof(RegisterStudent), new { }, student);
    }
    
    [HttpPost("/register/professor")]
   public async Task<ActionResult<ProfessorDto>> RegisterProfessor ([FromForm] CreateProfessorRequest request)
    {
        var command = new CreateProfessorCommand()
        {
            Email = request.Email,
            Password = request.Password,
            ConfirmPassword = request.ConfirmPassword,
            Name = request.Name,
            Surname = request.Surname,
            ProfilePictureUrl = request.ProfilePicture?.OpenReadStream(),
            Subjects = request.Subjects.Split(","),
        };

        var professor = await _mediator.Send(command);

        return CreatedAtAction(nameof(RegisterProfessor), new { }, professor);
    }

}