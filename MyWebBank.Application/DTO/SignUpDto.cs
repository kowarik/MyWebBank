using System.ComponentModel.DataAnnotations;

namespace MyWebBank.Application.DTO
{
    public class SignUpDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        //enum UserRoles
        public string Role { get; set; } = "User";
    }
}
