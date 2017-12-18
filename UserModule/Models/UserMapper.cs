using AutoMapper;
using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Models;
using UserModule.Serives;

namespace UserModule.Models
{
    class UserMapper : IUserMapper
    {

        private static readonly IUserService _userService = new UserService();

        public UserMapper()
        {
        }
        public  UserMasterDto MapToUser(UserMaster userEntity)
        {
            //map common fields
            var user = Mapper.Map<UserMasterDto>(userEntity);


            return user;
        }
        public UserMaster MapToUserDto(UserMasterDto userEntity)
        {
            //map common fields
            var user = Mapper.Map<UserMaster>(userEntity);


            return user;
        }
    }
    public interface IUserMapper
    {
        UserMasterDto MapToUser(UserMaster user);
        UserMaster MapToUserDto(UserMasterDto model);

    }

}
 