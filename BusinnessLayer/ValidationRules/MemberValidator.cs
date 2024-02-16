using EntityLayer.Concrete;
using FluentValidation;

namespace BusinnessLayer.ValidationRules
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {

            RuleFor(x => x.UserName)
                    .NotEmpty().WithMessage("Boş Bırakılamaz.")
                    .MaximumLength(25).WithMessage("25 Karakterden az olmalıdır.")
                    .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");

            RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("Boş Bırakılamaz.")
                    .MaximumLength(25).WithMessage("25 Karakterden az olmalıdır.")
                    .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");
            RuleFor(x => x.LastName)
                    .NotEmpty().WithMessage("Boş Bırakılamaz.")
                    .MaximumLength(25).WithMessage("25 Karakterden az olmalıdır.")
                    .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");
            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
                    .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.Phone)
                    .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
                    .Matches(@"^\+?\d{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz.");

        }
    }
}
