using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace BardeMoeBack.Models
{
    public class Users
    {
        [Key]public int UserCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }   
        public string Name { get; set; }
    }
}
