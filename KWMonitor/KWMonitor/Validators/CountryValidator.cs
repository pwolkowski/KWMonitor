using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using KoronaWirusMonitor3.Models;

namespace KWMonitor.Validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(country => country.Name)
                .NotEmpty().WithMessage(Resource.CountryNameNotEmpty)
                .MinimumLength(3).WithMessage("Nazwa kraju musi być dłuższ niż 3 znak")
                .MaximumLength(20);
        }
    }
}
