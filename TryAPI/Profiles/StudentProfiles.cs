using System;
using AutoMapper;
using TryAPI.DTOs;
using TryAPI.Model;

namespace TryAPI.Profiles;

public class StudentProfiles : Profile
{
    public StudentProfiles()
    {
        CreateMap<Student, StudentDto>().ReverseMap();
        CreateMap<Student, StudentGetDto>()
            .ForMember(dest => dest.Professors, opt => opt.MapFrom(src => src.Professors));
        CreateMap<Student, StudentListItemDto>();
    }

}
