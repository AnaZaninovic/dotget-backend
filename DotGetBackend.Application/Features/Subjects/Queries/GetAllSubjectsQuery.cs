using AutoMapper;
using DotGetBackend.Application.Features.Subjects.Dtos;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Application.Features.Subjects.Queries;

public class GetAllSubjectsQuery : IRequest<ICollection<SubjectDto>>
{
    // nothing
}

public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, ICollection<SubjectDto>>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    
    public GetAllSubjectsQueryHandler( ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    public async Task<ICollection<SubjectDto>> Handle(GetAllSubjectsQuery query, CancellationToken cancellationToken)
    {
        var subjects = await _applicationContext.Subjects.ToListAsync(cancellationToken);
        return _mapper.Map<ICollection<SubjectDto>>(subjects);
    }
}