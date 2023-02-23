using System.ComponentModel.DataAnnotations;

namespace Example.Ecommerce.Application.DTO
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
    }
}
