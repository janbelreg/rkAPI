using System.ComponentModel.DataAnnotations;

namespace rkprodAPIx
{
    public class UserDto
    {
        //Data transfer object pre pouzivatela
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
