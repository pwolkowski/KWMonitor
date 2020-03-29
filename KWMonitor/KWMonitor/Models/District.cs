using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KoronaWirusMonitor3.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public Region Region { get; set; }
    }
}
