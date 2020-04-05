using FluentValidation;

namespace KWMonitor.Validators
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(i => i).NotEqual(0).NotNull().NotEmpty();
        }
    }
}
