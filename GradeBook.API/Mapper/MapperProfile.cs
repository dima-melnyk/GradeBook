using AutoMapper;
using GradeBook.BusinessLogic.DTOs;
using GradeBook.DataAccess.Entities;
using System;

namespace GradeBook.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreatePupilDTO, Pupil>();
            CreateMap<UpdatePupilDTO, Pupil>();
            CreateMap<Pupil, PupilDTO>().
                ForMember(p => p.Birthday, opt => opt.MapFrom(pd => pd.Birthday.ToString()));
        }
    }
}
