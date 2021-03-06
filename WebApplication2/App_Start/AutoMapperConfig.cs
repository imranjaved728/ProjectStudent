﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.DBEntities;
using WebApplication2.Models;

namespace WebApplication2.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<Tutor, TutorRegisterModel>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DOB, opts => opts.MapFrom(src => src.DateOfBirth));

            AutoMapper.Mapper.CreateMap<TutorRegisterModel, Tutor>()
               .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
               .ForMember(dest => dest.DateOfBirth, opts => opts.MapFrom(src => Convert.ToDateTime(src.DOB)));

            AutoMapper.Mapper.CreateMap<Tutor, TutorUpdateModel>()
                .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
                .ForMember(dest => dest.DOB, opts => opts.MapFrom(src => src.DateOfBirth.ToString("MM/dd/yyyy")))
                .ForMember(d => d.Expertise, o => o.MapFrom(s => s.tutorExperties.Select(c => c.category.CategoryID).ToArray()));

            AutoMapper.Mapper.CreateMap<TutorUpdateModel, Tutor>()
               .ForMember(dest => dest.FirstName, opts => opts.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opts => opts.MapFrom(src => src.LastName))
               .ForMember(dest => dest.DateOfBirth, opts => opts.MapFrom(src => src.DOB));



            AutoMapper.Mapper.CreateMap<Student, StudentRegisterModel>();
            AutoMapper.Mapper.CreateMap<StudentRegisterModel, Student>();


            AutoMapper.Mapper.CreateMap<Student, StudentUpdateModel>();
            AutoMapper.Mapper.CreateMap<StudentUpdateModel, Student>();

            AutoMapper.Mapper.CreateMap<QuestionViewModel, Question>();
            AutoMapper.Mapper.CreateMap<Question, QuestionViewModel>()
                 .ForMember(dest => dest.CategoryName, opts => opts.MapFrom(src => src.Categories.FirstOrDefault().CategoryName))
                 .ForMember(dest => dest.StudentProfile, opts => opts.MapFrom(src => src.student.ProfileImage))
                 .ForMember(dest => dest.StudentName, opts => opts.MapFrom(src => src.student.Username));

            AutoMapper.Mapper.CreateMap<TutorQuestionDetails, Question>();
            AutoMapper.Mapper.CreateMap<Question, TutorQuestionDetails>();

            
        }

    }
}