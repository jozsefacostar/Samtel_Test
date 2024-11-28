using Microsoft.EntityFrameworkCore;
using SamtelNetTest.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using TestSamtelNET.Infraestructure.Entities;
using TestSamtelNET.Infraestructure.Interfaces;

namespace Infraestructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly SamtelContext _context;

        public AreaRepository(SamtelContext context)
        {
            this._context = context;
        }

        public bool AsignArea(Guid idArea, Guid IdUser)
        {
            var getUser = _context.Users.Where(x => x.Id.Equals(IdUser)).FirstOrDefault();
            if (getUser != null)
            {
                getUser.Area = idArea;
                _context.Update(getUser);
                _context.SaveChanges();
            }
            return true;
        }
        public List<AreasDTO> GetAreas() => _context.Areas.AsNoTracking().Select(x => new AreasDTO { ID = x.Id, Name = x.Name }).AsQueryable().ToList();

    }
}