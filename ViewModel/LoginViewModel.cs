using MovieManage.Constant;
using System.ComponentModel.DataAnnotations;

namespace MovieManage.ViewModel
{
   

    public class LoginViewModel
    {
        [Required(ErrorMessage = MessagesValidation.RequiredEmail)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = MessagesValidation.RequiredPassword)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public bool Status { get; set; }

        public bool RememberMe { get; set; }
    }
}
