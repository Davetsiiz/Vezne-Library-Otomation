using EntityLayer.Concrete;
using FluentValidation;

namespace BusinnessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator() {

            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("Boş Bırakılamaz.")
                    .MaximumLength(50).WithMessage("50 Karakterden az olmalıdır.")
                    .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");

        }
    }
}
