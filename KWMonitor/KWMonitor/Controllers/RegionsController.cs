using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoronaWirusMonitor3.Models;
using KoronaWirusMonitor3.Repository;
using KWMonitor.DTO;
using KWMonitor.Services;
using KWMonitor.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KWMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly KWMContext _context;
        private readonly IRegionServices _regionServices;

        public RegionsController(KWMContext context, IRegionServices regionServices)
        {
            _context = context;
            _regionServices = regionServices;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Region>>> GetRegions()
        {
            return await _regionServices.GetAll();
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public ActionResult<Region> GetRegion(int id)
        {
            var validator = new IdValidator();
            var result = validator.Validate(id);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            var region = _regionServices.GetById(id);
            if (region == null) return NotFound();
            return region;
        }

        // PUT: api/Regions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.Id) return BadRequest();
            var validator = new RegionValidator();
            var resultValid = validator.Validate(region);
            if (!resultValid.IsValid)
            {
                return BadRequest(resultValid.Errors);
            }
            var result = await _regionServices.Update(region);
            if(result)
            {
                return Ok();
            }
            return NoContent();
        }

        // POST: api/Regions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(RegionDto region)
        {
            var newRegion = _context.Regions.Add(
                new Region
                {
                    Name = region.Name,
                    CountryId = region.CountryId
                });
            await _context.SaveChangesAsync();
            var response = _context.Regions.Include(r => r.Country).FirstOrDefault(r => r.Id == newRegion.Entity.Id);
            return CreatedAtAction("GetRegion", new {id = response.Id}, response);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Region>> DeleteRegion(int id)
        {
            var region = await _context.Regions.FindAsync(id);
            if (region == null) return NotFound();
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();
            return region;
        }

        
    }
}
