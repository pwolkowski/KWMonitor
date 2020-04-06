using System.Collections.Generic;
using System.Threading.Tasks;
using KoronaWirusMonitor3.Models;
using KoronaWirusMonitor3.Repository;
using Microsoft.EntityFrameworkCore;

namespace KWMonitor.Services
{
    public class CountryService : ICountriesService
    {
        private readonly KWMContext _context;

        public CountryService(KWMContext context)
        {
            _context = context;
        }

        public async Task<bool> Update(int id, Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
        }

        public async Task<List<Country>> GetAll()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetById(int id)
        {
            return await _context.Countries.FindAsync(id);
        }

        public async Task Delete(Country country)
        {
            _context.Countries.Remove(country);
            await _context.SaveChangesAsync();
        }

        public async Task<Country> Add(Country country)
        {
            var result = _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
