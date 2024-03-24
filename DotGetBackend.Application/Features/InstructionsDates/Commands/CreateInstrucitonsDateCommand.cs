using AutoMapper;
using DotGetBackend.Application.Features.InstructionsDates.Dtos;
using DotGetBackend.Domain.Enums;
using DotGetBackend.Infrastructure.Context;
using MediatR;

namespace DotGetBackend.Application.Features.InstructionsDates.Commands;

public class CreateInstrucitonsDateCommand : IRequest<InstructionsDateDto>
{
    public DateTime Date { get; set; }
    public Guid ProfessorId { get; set; }
    public Guid SubjectId { get; set; }
}

public class CreateInstrucitonsDateCommandHandler : IRequestHandler<CreateInstrucitonsDateCommand, InstructionsDateDto>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;
    
    public CreateInstrucitonsDateCommandHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    public async Task<InstructionsDateDto> Handle(CreateInstrucitonsDateCommand command, CancellationToken cancellationToken)
    {
        /*Professor professor = await _applicationContext.Professors
            .Where(p => p.Id == command.ProfessorId)
            .FirstOrDefault(cancellationToken);*/
        
        var instructionsDate = new Domain.Entities.InstructionsDate()
        {
            Date = command.Date,
            Status = InstructionDateStatus.Pending,
            
            ProfessorId = command.ProfessorId,
            SubjectId = command.SubjectId
            
        };

        _applicationContext.InstructionsDates.Add(instructionsDate);
        await _applicationContext.SaveChangesAsync(cancellationToken);

        return _mapper.Map<InstructionsDateDto>(instructionsDate);

    }
}