﻿using AutoMapper;
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
        }
    }
}
