using System.ComponentModel.DataAnnotations;

namespace rkprodAPIx
{
    public class User
    {
        //trieda pre celkove urcenie tabulky pouzivatela
        public int Id { get; set; }

        [Key] 
        public string Username { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
