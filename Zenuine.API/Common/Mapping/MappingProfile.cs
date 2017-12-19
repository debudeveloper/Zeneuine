using AutoMapper;
using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zenuine.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Dto
           // Mapper.CreateMap<UserMaster, UserMasterDto>();
          
            // Dto to Domain
          //  Mapper.CreateMap<UserMasterDto, UserMaster>();
             }
    }
}