using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.Id).NotEmpty();
            RuleFor(p => p.Password).NotEmpty();
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.LastName).NotEmpty();
        }
    }
}