using MovieManage.ViewModel;
using System.Security.Claims;

namespace MovieManage.Utills
{
    public class UserInfoHelper
    {
        public static UserInformationViewModel GetUserInfo(HttpContext? context)
        {
            var email = context?.User.FindFirst(ClaimTypes.Email)?.Value;
            
            var name = context?.User.FindFirst(ClaimTypes.Name)?.Value;
            var userIdClaim = context?.User.FindFirst("UserId")?.Value;

            int.TryParse(userIdClaim, out int userId);

            return new UserInformationViewModel
            {
                Email = email,
                Name = name,
                UserId = userId,
               
            };
        }
    }
}
