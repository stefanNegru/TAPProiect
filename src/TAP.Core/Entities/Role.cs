using System;

namespace TAP.Core.Entities
{
    public class Role : IEntityBase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}