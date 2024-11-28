using SamtelNetTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using TestSamtelNET.Infraestructure.Interfaces;

namespace TestSamtelNET.Domain.Services
{
    public class AreaService
    {
        private readonly IAreaRepository _areaRepository;
        public AreaService(IAreaRepository iareaRepository)
        {
            _areaRepository = iareaRepository;
        }
        public bool AsignArea(Guid IdArea, Guid IdUser) =>
              _areaRepository.AsignArea(IdArea, IdUser);
        public List<AreasDTO> GetArea() => _areaRepository.GetAreas();
    }
}
