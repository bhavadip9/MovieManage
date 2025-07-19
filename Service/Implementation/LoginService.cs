using MovieManage.Models;
using MovieManage.Repository.Implementation;
using MovieManage.Repository.Interfaces;
using MovieManage.Service.Interfaces;
using MovieManage.Utills;
using MovieManage.ViewModel;

namespace MovieManage.Service.Implementation
{
   


    public class LoginService: ILoginService
    {

        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
            
        }

        public bool IsEmailExists(string email)
        {
            return  _loginRepository.IsUserExists(email);
            
        }
        public User RegisterUser(UserRegisterViewModel userRegisterVM)
        {
            User user = new User
            {
                FullName = userRegisterVM.FullName,
                Email = userRegisterVM.Email,
                Mobile = userRegisterVM.Phone,
                Password = PasswordUtills.HashPassword(userRegisterVM.Password)
            };
            return _loginRepository.AddUser(user);
        }
        public UserRegisterViewModel UserLogin(LoginViewModel loginVM)
        {

            User userData = _loginRepository.GetUserByEmail(loginVM.Email);


            UserRegisterViewModel userRegister = new UserRegisterViewModel
            {
                UserId = userData.UserId,
                FullName = userData.FullName,
                Email = userData.Email,
                Phone = userData.Mobile,
                Password = userData.Password
            };

            if (userData != null)
            {
                var VerifyPassword = PasswordUtills.VerifyPassword(loginVM.Password, userData.Password);
                if (VerifyPassword)
                {
                    return userRegister;
                }
                else
                {
                    userRegister.Password = string.Empty;
                    return userRegister;
                }
            }
            return null;

        }
    }
}
