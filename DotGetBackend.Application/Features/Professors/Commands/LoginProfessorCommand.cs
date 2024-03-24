using AutoMapper;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Application.Features.Professors.Commands;

public class LoginProfessorCommand : IRequest<ProfessorLoginDto>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}

public class LoginProfessorCommandHandler : IRequestHandler<LoginProfessorCommand, ProfessorLoginDto>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    
    public LoginProfessorCommandHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public async Task<ProfessorLoginDto> Handle(LoginProfessorCommand command, CancellationToken cancellationToken)
    {
        var professor = await _applicationContext.Professors.FirstOrDefaultAsync(
            p => p.Email == command.Email && p.Password == command.Password,
            cancellationToken);
        
        if (professor == null)
        {
            return new ProfessorLoginDto()
            {
                Success = false,
                Message = "Invalid email or password",
            };
        }
        
        return new ProfessorLoginDto()
        {
            Professor = _mapper.Map<ProfessorDto>(professor),
            Success = true,
            Message = "Login successful",
        };
    }
}