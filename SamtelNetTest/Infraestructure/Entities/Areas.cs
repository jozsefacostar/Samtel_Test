using System;
using System.Collections.Generic;

namespace TestSamtelNET.Infraestructure.Entities
{
    public partial class Areas
    {
        public Areas()
        {
            Users = new HashSet<Users>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public byte Active { get; set; }

        public virtual ICollection<Users> Users { get; set; }
    }
}
