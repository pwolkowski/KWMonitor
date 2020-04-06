using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoronaWirusMonitor3.Models;
using KoronaWirusMonitor3.Repository;
using Microsoft.EntityFrameworkCore;

namespace KWMonitor.Services
{
    public class RegionService : IRegionService
    {
        private readonly KWMContext _context;

        public RegionService(KWMContext context)
        {
            _context = context;
        }
        public async Task<List<Region>> GetAll()
        {
            return await _context.Regions.Include(c => c.Country).ToListAsync();
        }

        public Region GetById(int id)
        {
            return _context.Regions.Include(r => r.Country).FirstOrDefault(r => r.Id == id);
        }

        public async Task<bool> Update(Region region)
        {
            _context.Entry(region).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(region.Id))
                    return false;
                throw;
            }
            return true;
        }

        private bool RegionExists(int id)
        {
            return _context.Regions.Any(e => e.Id == id);
        }
    }
}
