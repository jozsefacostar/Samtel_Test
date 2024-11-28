using SamtelNetTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using TestSamtelNET.Infraestructure.Interfaces;

namespace TestSamtelNET.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository iuserRepository)
        {
            _userRepository = iuserRepository;
        }
        public bool CreateUser(string Name, string LastName, string Address, DateTime Birthday) =>
      _userRepository.CreateUser(new UserDTO(Name, LastName, Address, Birthday));

        public bool EditUser(Guid id, string Name, string LastName, string Address, DateTime Birthday) =>
    _userRepository.EditUser(new UserDTO(id, Name, LastName, Address, Birthday));

        public List<UserDTO> GetUsers() => _userRepository.GetUsers();

    }
}
