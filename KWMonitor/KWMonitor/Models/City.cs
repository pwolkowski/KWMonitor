using System.ComponentModel.DataAnnotations;

namespace KoronaWirusMonitor3.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public District District { get; set; }
    }
}
