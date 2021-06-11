using System;
using System.Collections.Generic;
using System.Text;

namespace TAP.Core.Entities
{
    public class Blog : IEntityBase
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        //public User Author { get; set; }
        public string Content { get; set; }
    }
}
