using System.ComponentModel.DataAnnotations;

namespace Core.Infrastructure.Domain.Contract.DTO.Login
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid E-Mail Address")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "PASSWORD_MIN_LENGTH", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]public bool EmailConfirmed { get; set; }
    }
}