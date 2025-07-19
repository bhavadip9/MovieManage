using MovieManage.ViewModel;

namespace MovieManage.Service.Interfaces
{
    public interface ICookieService
    {
        void SaveJWTToken(HttpResponse response, string token);

        string? GetJWTToken(HttpRequest request);

        void SaveRememberMe(HttpResponse response, UserRegisterViewModel user);

        void ClearCookies(HttpContext httpContext);
    }
}
