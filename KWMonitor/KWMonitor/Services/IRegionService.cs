using KoronaWirusMonitor3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KWMonitor.Services
{
    public interface IRegionService
    {
        Task<List<Region>> GetAll();
        Region GetById(int id);
        Task<bool> Update(Region region);
    }
}