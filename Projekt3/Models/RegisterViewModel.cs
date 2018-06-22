using System.ComponentModel.DataAnnotations;

namespace Projekt3.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Login")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password does not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "UserRole")]
        public string UserRole { get; set; }
    }
}
