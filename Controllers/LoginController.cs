using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieManage.Constant;
using MovieManage.Service.Interfaces;
using MovieManage.ViewModel;

namespace MovieManage.Controllers
{
    public class LoginController : Controller
    {

       
        private readonly IJwtService _jwtService;
        private readonly ICookieService _cookieService;
        private readonly ISessionService _sessionService;
        private readonly ILoginService _loginService;

        public LoginController(IJwtService jwtService, ICookieService cookieService, ISessionService sessionService, ILoginService loginService)
        {
            _jwtService = jwtService;
            _cookieService = cookieService;
            _sessionService = sessionService;
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }


       
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View(); // returns Register.cshtml
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Save logic here
                return RedirectToAction("Login", "Login");
            }

             bool isEmailExists = _loginService.IsEmailExists(model.Email);
            if (isEmailExists)
            {
                TempData["error"] = Messages.ErrorMessageEmailExist;
                return View(model);
            }


            _loginService.RegisterUser(model);
            TempData["success"] = "Registration successful! Please login.";

            return RedirectToAction("Login");
        }

  

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            
            var userFromSession = _sessionService.GetUser(HttpContext);

            if (userFromSession != null && !string.IsNullOrEmpty(userFromSession.Email))
            {
                return RedirectToAction("Index", "Home");
            }

           
            _sessionService.ClearSession(HttpContext);
            _cookieService.ClearCookies(HttpContext);

            return View();
        }


        public IActionResult Login(LoginViewModel loginViewModel)

        {
            if (ModelState.IsValid)
            {

                UserRegisterViewModel userData = _loginService.UserLogin(loginViewModel);
                if (userData != null)
                {
                    if (string.IsNullOrEmpty(userData.Email))
                    {
                        TempData["error"] = Messages.ErrorMessageEmail;
                        return View(loginViewModel);
                    }

                    if (string.IsNullOrEmpty(userData.Password))
                    {
                        TempData["error"] = Messages.ErrorMessagePassword;
                        return View(loginViewModel);
                    }
                }
                else
                {
                    TempData["error"] = Messages.ErrorMessageRegister;
                    return View(loginViewModel);
                }

              
                string token = _jwtService.GenerateJwtToken(userData.FullName, userData.Email, userData.UserId ?? 0);

                _cookieService.SaveJWTToken(Response, token);

                if (loginViewModel.RememberMe)
                {
                    _cookieService.SaveRememberMe(Response, userData);
                }

                // Store User details in Session
                _sessionService.SetUser(HttpContext, userData);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(loginViewModel);
            }
        }
        public IActionResult Logout()
        {
            //     Clear out all the Cookie data
            _cookieService.ClearCookies(HttpContext);

            //     Clear out all the Session data
            _sessionService.ClearSession(HttpContext);
            return RedirectToAction("Login");
        }
    }

}
