using System.ComponentModel.DataAnnotations;

namespace TAP.Web.Areas.PlaylistArea.Models
{
    public class BlogCreateViewModel
    {
        [Required(ErrorMessage = "Please Enter A Title")]
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
    }
}