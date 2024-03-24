using AutoMapper;
using DotGetBackend.Application.Features.Subjects.Dtos;
using DotGetBackend.Domain.Entities;

namespace DotGetBackend.Application.Profiles;

public class SubjectProfile: Profile
{
    public SubjectProfile()
    {
        CreateMap<Subject, SubjectDto>();
    }
}