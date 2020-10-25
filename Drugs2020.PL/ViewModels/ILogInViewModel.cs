using Drugs2020.BLL.BE;

namespace Drugs2020.PL.ViewModels
{
    interface ILogInViewModel
    {
        string Password { get; set; }
        string UserId { get; set; }
        IUser User { get; set; }
        void IdentifyUser();
        bool ValidatePassword();
        void LogUserIn(string id);
    }
}