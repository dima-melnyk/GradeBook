using AutoMapper;
using GradeBook.BusinessLogic.Models;
using GradeBook.DataAccess.Entities;

namespace GradeBook.API.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreatePupil, Pupil>();
            CreateMap<UpdatePupil, Pupil>();
            CreateMap<Pupil, PupilToView>().
                ForMember(p => p.Birthday, opt => opt.MapFrom(pd => pd.Birthday.ToString()));

            CreateMap<CreateClass, Class>();
            CreateMap<Class, ClassToView>()
                .ForMember(c => c.PupilQuantity, opt => opt.MapFrom(cd => cd.Pupils.Count));
        }
    }
}
