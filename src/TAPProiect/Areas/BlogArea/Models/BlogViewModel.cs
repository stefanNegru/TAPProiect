using System;
using System.Collections.Generic;
using TAP.Core.Entities;

namespace TAP.Web.Areas.BlogArea.Models
{
    public class BlogViewModel
    {
        public User Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}