using AutoMapper;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Application.Features.Professors.Queries;

public class GetAllProfessorsQuery : IRequest<ICollection<ProfessorDto>>
{
    //sending nothing
}

public class GetAllProfessorsHandler : IRequestHandler<GetAllProfessorsQuery, ICollection<ProfessorDto>>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    
    public GetAllProfessorsHandler( ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }

    public async Task<ICollection<ProfessorDto>> Handle(GetAllProfessorsQuery query,
        CancellationToken cancellationToken)
    {
        var professors = await _applicationContext.Professors.ToListAsync(cancellationToken);
        return _mapper.Map<ICollection<ProfessorDto>>(professors);
    }
}