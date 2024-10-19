using System.ComponentModel.DataAnnotations;

namespace LT.Core.ModelEntities
{
    public class LoginModel
    {
        [Key]
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}
