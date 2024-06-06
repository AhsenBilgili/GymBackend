using AutoMapper;
using DenemeForeignKey.DTOs;
using DenemeForeignKey.Entities;

namespace DenemeForeignKey.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CourseCreateDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CoursePrice, CoursePriceCreateDto>().ReverseMap();
            CreateMap<PaymentType, PaymentTypeCreateDto>().ReverseMap();
            CreateMap<HomePageCard, HomePageCardCreateDto>().ReverseMap();



        }
    }
}
