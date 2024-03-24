using AutoMapper;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Application.Features.Subjects.Dtos;
using DotGetBackend.Domain.Entities;
using DotGetBackend.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotGetBackend.Application.Features.Subjects.Queries;

public class GetSubjectByUrlQuery: IRequest<SubjectByUrlDto>
{
    public string Url { get; set; }
}

public class GetSubjectByUrlQueryHandler: IRequestHandler<GetSubjectByUrlQuery, SubjectByUrlDto>
{
    private readonly ApplicationContext _applicationContext;
    private readonly IMapper _mapper;

    public GetSubjectByUrlQueryHandler(ApplicationContext applicationContext, IMapper mapper)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
    }
    
    public async Task<SubjectByUrlDto> Handle(GetSubjectByUrlQuery query, CancellationToken cancellationToken)
    {
        var subject = await _applicationContext.Subjects
            .Where(s => s.Url == query.Url)
            .Include(s => s.ProfessorSubjects!)
            .ThenInclude(ps => ps.Professor)
            .FirstOrDefaultAsync(cancellationToken);

        if (subject == null)
        {
            return new SubjectByUrlDto()
            {
                Success = false,
                Message = "Subject not found",
            };
        }

        return new SubjectByUrlDto()
        {
            Success = true,
            Subject = _mapper.Map<SubjectDto>(subject),
            Professors = _mapper.Map<ICollection<ProfessorDto>>(subject.ProfessorSubjects!.Select(ps => ps.Professor)),
            Message = "Subject found",
        };
    }
}
