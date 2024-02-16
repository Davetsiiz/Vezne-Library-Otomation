using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.ValidationRules
{
    public class RegisteValidator : AbstractValidator<Member>
    {
        public RegisteValidator()
        {
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
            RuleFor(x => x.Password)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Şifre boş olamaz.")
                    .MinimumLength(8).WithMessage("Şifre en az 8 karakter uzunluğunda olmalıdır.")
                    .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                    .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                    .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir.")
                    .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir.");

        }
    }
}
