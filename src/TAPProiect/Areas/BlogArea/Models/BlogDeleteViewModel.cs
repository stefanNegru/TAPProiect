using System;
using System.ComponentModel;

namespace TAP.Web.Areas.BlogArea.Models
{
    public class BlogDeleteViewModel
    {
        [DisplayName("Blog Title")]
        public string BlogTitle { get; set; }

        public Guid UserId { get; set; }
        public Guid BlogId { get; set; }
    }
}