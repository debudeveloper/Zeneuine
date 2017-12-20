using Modules.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modules.User.Services
{
    public interface IUserService
    {
        List<InputUserMasterDto> GetAllUser();
        InputUserMasterDto GetUserById(int id);
        InputUserMasterDto GetUserByPhoneNumber(string phone);
        InputUserMasterDto GetUserByPhoneNumberOrId(string phone, int id);

        int SaveUser(InputUserMasterDto user);
        bool ChangePassword(string verificationCode, string password);
        bool SendResetPasswordEmail(string userName, string clientId);
        bool IsAlreadyEXists(string phoneNumber);

    }
}
