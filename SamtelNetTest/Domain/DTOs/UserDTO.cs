using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamtelNET.Infraestructure.Entities;

namespace SamtelNetTest.Domain.DTOs
{
    public class UserDTO
    {
        public UserDTO() { }
        public UserDTO(string Name, string LastName, string Address, DateTime Birthday)
        {
            this.Id = Guid.NewGuid();
            this.Name = Name;
            this.LastName = LastName;
            this.Address = Address;
            this.Birthday = Birthday;
        }

        public UserDTO(Guid id, string Name, string LastName, string Address, DateTime Birthday)
        {
            this.Id = id;
            this.Name = Name;
            this.LastName = LastName;
            this.Address = Address;
            this.Birthday = Birthday;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public Guid? IdArea { get; set; }
        public string Area { get; set; }
    }
}
