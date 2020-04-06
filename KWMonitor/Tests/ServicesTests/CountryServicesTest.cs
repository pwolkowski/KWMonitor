using System.Collections.Generic;
using System.Linq;
using KWMonitor.Services;
using System.Threading.Tasks;
using KoronaWirusMonitor3.Models;
using KWMonitor.Controllers;
using Moq;
using Xunit;

namespace ServicesTests
{
    public class CountryServicesTest
    {
        private Mock<ICountriesService> _countryService = new Mock<ICountriesService>();
        private CountriesController _countriesController;

        public CountryServicesTest()
        {
            _countriesController = new CountriesController(_countryService.Object);
        }

        [Fact]
        public async Task CountryController_GetCountries()
        {
            //arrange
            _countryService.Setup(s => s.GetAll()).ReturnsAsync(() => new List<Country>() { new Country(){Name = "Polska", Id = 1}});
            //act
            var result = await _countriesController.GetCountries();
            //assert
            Assert.Equal(1, result.Value.Count());
            //Assert.Equal(1, result.Value.First()?.Id);
            //Assert.Equal("Polska", result.Value.First().Name);
        }
    }
}
