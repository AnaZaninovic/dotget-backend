using AutoMapper;
using DotGetBackend.Application.Features.Students.Dtos;
using DotGetBackend.Domain.Entities;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Application.Features.Students.Commands;

public class LoginStudentCommand : IRequest<StudentLoginDto>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}

public class LoginStudentCommandHandler : IRequestHandler<LoginStudentCommand, StudentLoginDto>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public LoginStudentCommandHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public async Task<StudentLoginDto> Handle(LoginStudentCommand command, CancellationToken cancellationToken)
    {
        var student = await _applicationContext.Students.FirstOrDefaultAsync(
            s => s.Email == command.Email && s.Password == command.Password,
            cancellationToken);

        if (student == null)
        {
            return new StudentLoginDto()
            {
                Success = false,
                Message = "Invalid email or password",
            };
        }

        return new StudentLoginDto()
        {
            Student = _mapper.Map<StudentDto>(student),
            Success = true,
            Message = "Login successful",
        };
    }
}