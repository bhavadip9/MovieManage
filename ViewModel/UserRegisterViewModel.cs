using MovieManage.Constant;
using System.ComponentModel.DataAnnotations;

namespace MovieManage.ViewModel
{
    public class UserRegisterViewModel
    {

        public int? UserId { get; set; }

        [Required(ErrorMessage = MessagesValidation.RequiredFullName)]
        public string FullName { get; set; } = null!;

      

        [Required(ErrorMessage = MessagesValidation.RequiredPassword)]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = MessagesValidation.PasswordLength)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[a-zA-Z]).{8,}$",
    ErrorMessage = MessagesValidation.PasswordPattern)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = MessagesValidation.RequiredConfirmPassword)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = MessagesValidation.PasswordMismatch)]
        public string ConfirmPassword { get; set; } = null!;


        [Required(ErrorMessage = MessagesValidation.RequiredEmail)]
        [EmailAddress]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = MessagesValidation.RequiredMobileNumber)]
        [Phone(ErrorMessage = MessagesValidation.InvalidPhoneNumber)]
        [RegularExpression(@"^\d{10}$", ErrorMessage = MessagesValidation.MobileNumberLength)]
        public string Phone { get; set; } = null!;



    }
}
