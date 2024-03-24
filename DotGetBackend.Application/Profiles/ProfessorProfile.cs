using AutoMapper;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotGetBackend.Application.Profiles;

public class ProfessorProfile: Profile
{
    public ProfessorProfile()
    {
        CreateMap<Professor, ProfessorDto>().ForMember(p => p.Subjects,
            opt => opt.MapFrom(p =>
                p.ProfessorSubjects == null? new List<string>() : p.ProfessorSubjects.Select(ps => ps.Subject.Url)));
    }
}