using AutoMapper;
using DotGetBackend.Application.Features.Students.Dtos;
using DotGetBackend.Domain.Entities;
using DotGetBackend.Infrastructure.Context;
using MediatR;

namespace DotGetBackend.Application.Features.Students.Commands;

public class CreateStudentCommand : IRequest<StudentDto>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public Stream? ProfilePicture { get; set; }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentDto>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public CreateStudentCommandHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public async Task<StudentDto> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var student = new Student()
        {
            Email = command.Email,
            Password = command.Password,
            Name = command.Name,
            Surname = command.Surname,
        };

        _applicationContext.Students.Add(student);
        await _applicationContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<StudentDto>(student);
    }
}