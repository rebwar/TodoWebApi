using System.ComponentModel.DataAnnotations;


namespace TodoApp.Dtos
{
    public class CreateUserDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}