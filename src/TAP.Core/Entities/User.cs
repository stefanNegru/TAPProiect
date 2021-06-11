using System;
using System.Collections.Generic;

namespace TAP.Core.Entities
{
    public class User : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
