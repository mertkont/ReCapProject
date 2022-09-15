using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ModelYear).NotEmpty();
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.BrandId).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0);
            RuleFor(p => p.ColorId).GreaterThanOrEqualTo(0).When(p => p.BrandId == 1);
            RuleFor(p => p.Description).Must(StartWithA).WithMessage("Products must start with the A letter.");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}