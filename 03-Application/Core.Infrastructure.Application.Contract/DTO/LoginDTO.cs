using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Security.Policy;

namespace Core.Infrastructure.Application.Contract.DTO
{
    [DataContract]
    public class LoginDTO
    {
        [EmailAddress][DataMember] [Required] public string Email { get; set; }
        [DataMember] [Required] public string Password { get; set; }
    }
}