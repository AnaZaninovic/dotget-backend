using AutoMapper;
using DotGetBackend.Application.Features.Students.Dtos;
using DotGetBackend.Domain.Entities;

namespace DotGetBackend.Application.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDto>();
    }
}