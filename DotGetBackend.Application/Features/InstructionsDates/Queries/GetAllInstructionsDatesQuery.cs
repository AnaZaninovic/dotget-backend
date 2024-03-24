using AutoMapper;
using DotGetBackend.Application.Features.InstructionsDates.Dtos;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Application.Features.InstructionsDates.Queries;

public class GetAllInstructionsDatesQuery : IRequest<ICollection<InstructionsDateDto>>
{
    //sending nada
}

public class GetAllInstructionsDatesQueryHandler : IRequestHandler<GetAllInstructionsDatesQuery, ICollection<InstructionsDateDto>>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    
    public GetAllInstructionsDatesQueryHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    public async Task<ICollection<InstructionsDateDto>> Handle(GetAllInstructionsDatesQuery query, CancellationToken cancellationToken)
    {
        var instructionsDates = await _applicationContext.InstructionsDates.ToListAsync(cancellationToken);
        return _mapper.Map<ICollection<InstructionsDateDto>>(instructionsDates);
    }
}