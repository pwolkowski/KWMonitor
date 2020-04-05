using FluentValidation;
using KoronaWirusMonitor3.Models;

namespace KWMonitor.Validators
{
    public class RegionValidator : AbstractValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(r => r.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(50);
            RuleFor(r => r.CountryId).NotNull().NotEqual(0);
        }
    }
}
