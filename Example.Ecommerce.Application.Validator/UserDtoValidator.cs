using Example.Ecommerce.Application.DTO;
using FluentValidation;

namespace Example.Ecommerce.Application.Validator
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator() => ValidatorRules();

        private void ValidatorRules()
        {
            RuleFor(u => u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}