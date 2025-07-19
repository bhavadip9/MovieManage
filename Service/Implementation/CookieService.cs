﻿using MovieManage.Service.Interfaces;
using MovieManage.ViewModel;
using System.Text.Json;

namespace MovieManage.Service.Implementation
{
    public class CookieService: ICookieService
    {
        public void SaveJWTToken(HttpResponse response, string token)
        {
            try
            {
                response.Cookies.Append("SuperSecretAuthToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddMinutes(60)
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string? GetJWTToken(HttpRequest request)
        {
            bool success_ = request.Cookies.TryGetValue("SuperSecretAuthToken", out string? token);
            return token;
        }

        public void SaveRememberMe(HttpResponse response, UserRegisterViewModel user)
        {
            string userData = JsonSerializer.Serialize(user);

            // Store user details in a cookie for 3 days
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(3),
                HttpOnly = true,
                Secure = true,
                IsEssential = true
            };

            response.Cookies.Append("UserData", userData, cookieOptions);
        }

        public void ClearCookies(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete("SuperSecretAuthToken");
            httpContext.Response.Cookies.Delete("UserData");
        }
    }
}
