using AutoMapper;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Domain.Entities;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Application.Features.Professors.Commands;

public class CreateProfessorCommand: IRequest<ProfessorDto>
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public Stream? ProfilePictureUrl { get; set; }
    public ICollection<string> Subjects { get; set; }
}

public class CreateProfessorCommandHandler : IRequestHandler<CreateProfessorCommand, ProfessorDto>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public CreateProfessorCommandHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    public async Task<ProfessorDto> Handle(CreateProfessorCommand command, CancellationToken cancellationToken)
    {
        var subjects = await _applicationContext.Subjects.Where(s => command.Subjects.Contains(s.Url)).ToListAsync(cancellationToken: cancellationToken);
        
        var professor = new Professor()
        {
            Email = command.Email,
            Password = command.Password,
            Name = command.Name,
            Surname = command.Surname,
            ProfessorSubjects = subjects.Select(s => new ProfessorSubject()
            {
                Subject = s,
            }).ToList(),
        };
        
        
        _applicationContext.Professors.Add(professor);
        await _applicationContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<ProfessorDto>(professor);
    }
}