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
    public class CountriesService
    {
        private readonly KWMContext _context;

        public CountriesService(KWMContext context)
        {
            _context = context;
        }

        public async Task<bool> PutCountry(int id, Country country)
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
    }
}
