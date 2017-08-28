using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication10.Dtos;
using WebApplication10.Models;

namespace WebApplication10.App_Start
{
    public class MappingProfile : Profile
    {
       
        public MappingProfile()
        {
            CreateMap<Member, MemberDto>();
           CreateMap<MemberDto, Member>();
        }
    }
}