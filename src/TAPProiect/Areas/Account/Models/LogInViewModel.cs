using System.ComponentModel.DataAnnotations;

namespace TAP.Web.Areas.Account.Models
{
    public class LogInViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}