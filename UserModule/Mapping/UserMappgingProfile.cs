using AutoMapper;
using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Models;

namespace UserModule.Mapping
{
    public class UserMappgingProfile : Profile
    {
        public UserMappgingProfile() {


            #region Model to Entity
            Mapper.CreateMap<UserMasterDto, UserMaster>()
                .IgnoreAllUnmapped()
             .ForMember(target => target.City, config => config.MapFrom(source => source.Name));


            #endregion

            #region Entity to Model

            Mapper.CreateMap<UserMaster, UserMasterDto>()
              .IgnoreAllUnmapped();
             // .ForMember(target => target.Email, config => config.MapFrom(source => source.UserName));


            #endregion
        }
    }
    public static class MappingExpressionExtensions
    {
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            expression.ForAllMembers(opt => opt.Ignore());
            return expression;
        }
    }
}
