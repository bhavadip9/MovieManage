using MovieManage.Models;
using MovieManage.ViewModel;

namespace MovieManage.Service.Interfaces
{
    public interface ILoginService
    {
        User RegisterUser(UserRegisterViewModel userRegisterVM);
        UserRegisterViewModel UserLogin(LoginViewModel loginVM);

        bool IsEmailExists(string email);
    }
}
