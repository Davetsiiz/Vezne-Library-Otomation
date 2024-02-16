using EntityLayer.Concrete;
using FluentValidation;

namespace BusinnessLayer.ValidationRules
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Boş Bırakılamaz.")
                    .MaximumLength(25).WithMessage("25 Karakterden az olmalıdır.")
                    .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");
            RuleFor(x => x.Barcode)
                    .NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x=>x.Piece)
                .NotEmpty().WithMessage("Boş Bırakılamaz.")
                .GreaterThan(0).WithMessage("0'dan büyük olmalıdır.");

        }
    }
}
