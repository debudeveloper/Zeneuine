using EntityDataAccess.Core;
using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using UserModule.Models;

namespace UserModule.Serives
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
        public List<UserMasterDto> GetAllUser()
        {
            var user= _context.Users.ToList();
           var v= _userMapper.MapToUser(user.ToList().FirstOrDefault());
            return null;
        }

        public UserMasterDto GetUserById(int id)
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

        public UserMasterDto GetUserByPhoneNumber(string phoneNumber)
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
       public UserMasterDto GetUserByPhoneNumberOrId(string phone,int id)
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

        public int SaveUser(UserMasterDto model)
        {
            UserMaster user = new UserMaster();
            user = _userMapper.MapToUserDto(model);
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.ID;
        }
        
    }
}