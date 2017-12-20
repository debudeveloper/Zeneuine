using AutoMapper;
using EntityObjects.Objects;
using Modules.Dtos;
using Modules.User.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Models
{
    class UserMapper : IUserMapper
    {

        private static readonly IUserService _userService = new UserService();

        public UserMapper()
        {
        }
        public InputUserMasterDto MapToUser(UserMaster userEntity)
        {
            //map common fields
            var user = Mapper.Map<InputUserMasterDto>(userEntity);


            return user;
        }
        public UserMaster MapToUserDto(InputUserMasterDto userEntity)
        {
            //map common fields
            var user = Mapper.Map<UserMaster>(userEntity);


            return user;
        }
    }
    public interface IUserMapper
    {
        InputUserMasterDto MapToUser(UserMaster user);
        UserMaster MapToUserDto(InputUserMasterDto model);

    }

}
