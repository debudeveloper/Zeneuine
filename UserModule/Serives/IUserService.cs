using EntityObjects.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserModule.Models;

namespace UserModule.Serives
{
   public interface IUserService
    {
        List<UserMasterDto> GetAllUser();
        UserMasterDto GetUserById(int id);
        UserMasterDto GetUserByPhoneNumber(string phone);
        UserMasterDto GetUserByPhoneNumberOrId(string phone,int id);

        int SaveUser(UserMasterDto user);
        bool ChangePassword(string verificationCode, string password);
        bool SendResetPasswordEmail(string userName, string clientId);
        bool IsAlreadyEXists(string phoneNumber);

    }
}
