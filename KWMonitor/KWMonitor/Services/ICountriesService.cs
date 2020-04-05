using KoronaWirusMonitor3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWMonitor.Services
{
    public interface ICountriesService
    {
        Task<Country> Add(Country country);
        Task Delete(Country country);
        Task<List<Country>> GetAll();
        Task<Country> GetById(int id);
        Task<bool> Update(int id, Country country);
    }
}