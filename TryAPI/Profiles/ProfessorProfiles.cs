using System;
using AutoMapper;
using TryAPI.DTOs;
using TryAPI.Model;

namespace TryAPI.Profiles;

public class ProfessorProfiles : Profile
{
    public ProfessorProfiles()
    {
        CreateMap<Professor, ProfessorDto>().ReverseMap();
        CreateMap<Professor, ProfessorGetDto>()
            .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students));
    }

}
