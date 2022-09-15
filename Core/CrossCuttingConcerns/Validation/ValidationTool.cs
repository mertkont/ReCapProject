using FluentValidation;

namespace Core.CrossCuttingConcerns.Validation
{
    public class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            // fluent validation ile burdaki kuralları eklemiş bulunduk ve çağırdık
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            // !, kural geçerli değil demek
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}