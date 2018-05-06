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
            CreateMap<TestDTO, Test>();

            CreateMap<TestQuestion, TestQuestionDTO>();
            CreateMap<TestQuestionDTO, TestQuestion>();

            CreateMap<TestQuestionAnswerDTO, TestQuestionAnswer>();
            CreateMap<TestQuestionAnswer, TestQuestionAnswerDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();

            CreateMap<UserTestAnswer, UserTestAnswerDTO>();
            CreateMap<UserTestAnswerDTO, UserTestAnswer>();

            CreateMap<UserTestDTO, UserTest>();
            CreateMap<UserTest, UserTestDTO>();
        }
    }
}
