using Microsoft.EntityFrameworkCore;
using SamtelNetTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestSamtelNET.Infraestructure.Entities;
using TestSamtelNET.Infraestructure.Interfaces;

namespace Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SamtelContext _context;

        public UserRepository(SamtelContext samtelContext)
        {
            _context = samtelContext;
        }
        public bool CreateUser(UserDTO Users)
        {
            var mapObjectUser = new Users { Id = Users.Id, Name = Users.Name, LastName = Users.LastName, Address = Users.Address, Birthday = Users.Birthday };
            _context.Users.Add(mapObjectUser);
            _context.SaveChanges();
            return true;
        }

        public bool EditUser(UserDTO Users)
        {
            var getUser = _context.Users.Where(x => x.Id.Equals(Users.Id)).FirstOrDefault();
            if (getUser != null)
            {
                getUser.Name = Users.Name;
                getUser.LastName = Users.LastName;
                getUser.Address = Users.Address;
                getUser.Birthday = Users.Birthday;
                _context.Users.Update(getUser);
                _context.SaveChanges();
            }
            return true;
        }

        public List<UserDTO> GetUsers() =>
            _context.Users.AsNoTracking()
            .Select(x => new UserDTO
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                Address = x.Address,
                Birthday = x.Birthday,
                IdArea = x.AreaNavigation.Id,
                Area = x.AreaNavigation.Name
            }).ToList();

    }
}
