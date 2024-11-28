using System;
using System.Collections.Generic;

namespace TestSamtelNET.Infraestructure.Entities
{
    public partial class Users
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public Guid? Area { get; set; }
        public virtual Areas AreaNavigation { get; set; }
    }
}
