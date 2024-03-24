using AutoMapper;
using DotGetBackend.Application.Features.InstructionsDates.Dtos;
using DotGetBackend.Domain.Entities;

namespace DotGetBackend.Application.Profiles;

public class InstructionsDateProfile: Profile
{
    public InstructionsDateProfile()
    {
        CreateMap<InstructionsDate, InstructionsDateDto>();
    }
}