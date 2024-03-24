using DotGetBackend.Application.Features.Professors.Commands;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Application.Features.Students.Commands;
using DotGetBackend.Application.Features.Students.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TicTacToeBackend.Utils;

namespace dotget_backend.Controllers;

[ApiController]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly string _jwtSecret;

    public LoginController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _jwtSecret = configuration["Jwt:Secret"];
    }

    [HttpPost("/login/student")]
    [Consumes("application/json")]
    public async Task<ActionResult<StudentDto>> LoginStudent([FromBody] LoginStudentCommand command)
    {
        var studentLoginDto = await _mediator.Send(command);

        if (studentLoginDto.Student is null) return Unauthorized(studentLoginDto);
        
        studentLoginDto.Token = TokenUtils.GenerateJwToken(studentLoginDto.Student, _jwtSecret);

        return Ok(studentLoginDto);

    }
    
    [HttpPost("/login/professor")]
    [Consumes("application/json")]
    public async Task<ActionResult<ProfessorDto>> LoginProfessor([FromBody] LoginProfessorCommand command)
    {
        var professorLoginDto = await _mediator.Send(command);

        if (professorLoginDto.Professor is null) return Unauthorized(professorLoginDto);

        professorLoginDto.Token = await TokenUtils.GenerateJwToken(professorLoginDto.Professor, _jwtSecret);

        return Ok(professorLoginDto);
    }
}