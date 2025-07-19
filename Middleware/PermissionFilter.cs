
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieManage.Service.Implementation;
using MovieManage.Service.Interfaces;

namespace MovieManage.Middleware
{
    public class LoginCheckFilter : IActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IJwtService _jwtService;

        public LoginCheckFilter(
            IHttpContextAccessor httpContextAccessor,
            IJwtService jwtService)
        {
            _httpContextAccessor = httpContextAccessor;
            _jwtService = jwtService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            
            var controller = context.RouteData.Values["controller"]?.ToString();
            var action = context.RouteData.Values["action"]?.ToString();

            if (controller == "Login" &&
                (action == "Login" || action == "Register" || action == "Logout"))
            {
                return; 
            }
            CookieService cookieService = new CookieService();
            string token = cookieService.GetJWTToken(context.HttpContext.Request)!;

            
            var principal = _jwtService.ValidateToken(token);

            if (principal == null)
            {
                
                context.Result = new RedirectToActionResult("Login", "Login", null);
                return;
            }

            
            context.HttpContext.User = principal;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           
        }
    }
}

