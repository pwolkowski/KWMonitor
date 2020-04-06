using System.Collections.Generic;
using System.Threading.Tasks;
using KoronaWirusMonitor3.Models;
using KoronaWirusMonitor3.Repository;
using KWMonitor.Services;
using KWMonitor.Validators;
using Microsoft.AspNetCore.Mvc;

namespace KWMonitor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            return await _countriesService.GetAll();
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var validator = new IdValidator();
            var result = validator.Validate(id);
            if (!result.IsValid) return BadRequest(result.Errors);
            var country = await _countriesService.GetById(id);
            if (country == null) return NotFound();
            return country;
        }

        // PUT: api/Countries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, Country country)
        {
            if (id != country.Id) return BadRequest();
            var validator = new CountryValidator();
            var resultValidator = validator.Validate(country);
            if (!resultValidator.IsValid) return BadRequest(resultValidator.Errors);
            var result = await _countriesService.Update(id, country);
            if (result) return Ok();
            return NoContent();
        }

        // POST: api/Countries
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Country>> PostCountry(Country country)
        {
            var validator = new CountryValidator();
            var resultValid = validator.Validate(country);
            if (!resultValid.IsValid) return BadRequest(resultValid.Errors);
            var result = _countriesService.Add(country);
            return CreatedAtAction("GetCountry", new {id = result.Id}, result);
        }

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = await _countriesService.GetById(id);
            if (country == null) return NotFound();
            await _countriesService.Delete(country);
            return Ok();
        }
    }
}
