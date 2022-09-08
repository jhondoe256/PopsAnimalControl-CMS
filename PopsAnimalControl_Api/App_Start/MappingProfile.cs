using AutoMapper;
using PAC.Data.DogCatchers;
using PAC.Models.DogCatcherModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PopsAnimalControl_Api.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<DogCatcher, DogCatcherListItem>();
            Mapper.CreateMap<DogCatcher, DogCatcherDetail>();
            Mapper.CreateMap<DogCatcher, DogCatcherCreate>().ReverseMap();
        }
    }
}