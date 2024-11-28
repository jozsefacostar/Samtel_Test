using SamtelNetTest.Domain.DTOs;
using System.Collections.Generic;

namespace TestSamtelNET.Infraestructure.Interfaces
{
    public interface IUserRepository
    {
        bool CreateUser(UserDTO Users);
        bool EditUser(UserDTO Users);
        List<UserDTO> GetUsers();
    }
}
