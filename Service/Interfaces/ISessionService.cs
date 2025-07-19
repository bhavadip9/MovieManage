using MovieManage.ViewModel;

namespace MovieManage.Service.Interfaces
{
    public interface ISessionService
    {

        void SetUser(HttpContext httpContext, UserRegisterViewModel user);

        UserRegisterViewModel? GetUser(HttpContext httpContext);

        void ClearSession(HttpContext httpContext);

    }
}
