using AutoMapper;
using EntityObjects.Objects;
using Modules.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zenuine.API.Dtos;

namespace Zenuine.API.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           // Domain to Dto
            Mapper.CreateMap<UserMaster, InputUserMasterDto>();
            Mapper.CreateMap<OutputCustomerDto, InputUserMasterDto>();

            // Dto to Domain
            Mapper.CreateMap<InputUserMasterDto, OutputCustomerDto>();

            Mapper.CreateMap<InputUserMasterDto, UserMaster>();
        }
    }
}