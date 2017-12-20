using AutoMapper;
using EntityObjects.Objects;
using Modules.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.Admin.Mapping
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            #region Model to Entity
            Mapper.CreateMap<InputCustomerDto, Customer>()
                .IgnoreAllUnmapped();
            //   .ForMember(target => target., config => config.MapFrom(source => source.Email));


            #endregion

            #region Entity to Model

            Mapper.CreateMap<Customer, InputCustomerDto>()
                  .IgnoreAllUnmapped();
            // .ForMember(target => target.Email, config => config.MapFrom(source => source.UserName));


            #endregion
        }
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
