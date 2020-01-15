using System.ComponentModel.DataAnnotations;

namespace Core.Infrastructure.Application.Contract.DTO
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid E-Mail Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Username { get; set; }
        public bool EmailConfirmed { get; set; }
    }
}