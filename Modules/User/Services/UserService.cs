using EntityDataAccess.Core;
using EntityObjects.Objects;
using Modules.Dtos;
using Modules.User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Services
{
    public class UserService : IUserService
    {
        private readonly EFDbContext _context = null;
        private static readonly IUserMapper _userMapper = new UserMapper();

        public UserService() : this(new EFDbContext())
        {

        }
        public UserService(EFDbContext context)
        {
            _context = context;
        }
        public List<InputUserMasterDto> GetAllUser()
        {
            var user = _context.Users.ToList();
            var v = _userMapper.MapToUser(user.ToList().FirstOrDefault());
            return null;
        }

        public InputUserMasterDto GetUserById(int id)
        {
            try
            {

                var userEntity = _context.Users.Where(m => m.ID == id).FirstOrDefault();

                if (userEntity == null)
                    throw new Exception();

                // var user = _userMapper.MapToUser(userEntity);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InputUserMasterDto GetUserByPhoneNumber(string phoneNumber)
        {
            try
            {

                var userEntity = _context.Users.Where(m => m.PhoneNumber.ToLower() == phoneNumber.ToLower()).FirstOrDefault();

                if (userEntity == null)
                    throw new Exception();

                // var user = _userMapper.MapToUser(userEntity);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public InputUserMasterDto GetUserByPhoneNumberOrId(string phone, int id)
        {
            var user = _context.Users.Where(m => m.PhoneNumber.Equals(phone) || m.ID == id).FirstOrDefault();
            var userDto = _userMapper.MapToUser(user);
            return userDto;

        }
        public bool ChangePassword(string verificationCode, string password)
        {
            return false;
        }
        public bool SendResetPasswordEmail(string userName, string clientId)
        {
            return false;
        }
        public bool IsAlreadyEXists(string userName)
        {
            return false;
        }

        public int SaveUser(InputUserMasterDto model)
        {
            UserMaster user = new UserMaster();
            user = _userMapper.MapToUserDto(model);
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.ID;
        }

    }
}