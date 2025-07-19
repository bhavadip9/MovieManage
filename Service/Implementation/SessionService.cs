using MovieManage.Service.Interfaces;
using MovieManage.ViewModel;
using System.Text.Json;

namespace MovieManage.Service.Implementation
{
    public class SessionService: ISessionService
    {
        public void SetUser(HttpContext httpContext, UserRegisterViewModel user)
        {
            if (user != null)
            {
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        WriteIndented = true
                    };

                    string userData = JsonSerializer.Serialize(user, options);
                    httpContext.Session.SetString("UserData", userData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Serialization Error: {ex.Message}");
                    throw;
                }
            }
        }


        //Get User From Sesstion
        public UserRegisterViewModel? GetUser(HttpContext httpContext)
        {

            string userData = httpContext.Session.GetString("UserData");

            if (string.IsNullOrEmpty(userData))
            {
                httpContext.Request.Cookies.TryGetValue("UserData", out userData);
            }

            return string.IsNullOrEmpty(userData) ? null : JsonSerializer.Deserialize<UserRegisterViewModel>(userData);
        }


        //ClearSesstion 
        public void ClearSession(HttpContext httpContext) => httpContext.Session.Clear();
    }
}


