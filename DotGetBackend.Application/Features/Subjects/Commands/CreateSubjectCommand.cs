using AutoMapper;
using DotGetBackend.Application.Features.Subjects.Dtos;
using DotGetBackend.Domain.Entities;
using DotGetBackend.Infrastructure.Context;
using MediatR;

namespace DotGetBackend.Application.Features.Subjects.Commands;

public class CreateSubjectCommand : IRequest<SubjectDto>
{
    public string Title { get; set; }
    public string Url { get; set; }
    public string Description { get; set; }
}

public class CreateSubjectCommandHandler: IRequestHandler<CreateSubjectCommand, SubjectDto>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    
    public CreateSubjectCommandHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    public async Task<SubjectDto> Handle(CreateSubjectCommand command, CancellationToken cancellationToken)
    {
        var subject = new Subject()
        {
            Title = command.Title,
            Url = command.Url,
            Description = command.Description,
        };

        _applicationContext.Subjects.Add(subject);
        await _applicationContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<SubjectDto>(subject);
        
    }
}

