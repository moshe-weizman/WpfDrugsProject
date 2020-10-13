using Drugs2020.BLL.BE;

namespace Drugs2020.PL.ViewModels
{
    interface ILogInViewModel
    {
        IUser IdentifyUser(string userId);
        bool ValidatePassword(IUser user, string password);
    }
}