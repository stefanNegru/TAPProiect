using System.ComponentModel.DataAnnotations;
using TAP.Core.Entities;

namespace TAP.Web.Areas.Account.Models
{
    public class EditUserViewModel
    {
        public User User { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        public string CurrentPassword { get; set; }
    }
}