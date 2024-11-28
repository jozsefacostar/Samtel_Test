using SamtelNetTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestSamtelNET.Infraestructure.Interfaces
{
    public interface IAreaRepository
    {
        bool AsignArea(Guid idArea, Guid IdUser);
        List<AreasDTO> GetAreas();
    }
}
