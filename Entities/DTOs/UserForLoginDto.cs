using Core.Entities;

namespace Entities.DTOs
{
    //DTO - Data Transformation Object

    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
