using System.ComponentModel.DataAnnotations;

namespace KoronaWirusMonitor3.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public District District { get; set; }
    }
}
