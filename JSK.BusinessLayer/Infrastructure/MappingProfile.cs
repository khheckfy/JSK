using AutoMapper;
using JSK.BusinessLayer.DTO;
using JSK.Domain.Entities;

namespace JSK.BusinessLayer.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Test, TestDTO>();
        }
    }
}
