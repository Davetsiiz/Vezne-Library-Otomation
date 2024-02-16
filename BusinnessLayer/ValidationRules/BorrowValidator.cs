using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.ValidationRules
{
    public class BorrowValidator:AbstractValidator<Borrow>
    {
        public BorrowValidator()
        {
            RuleFor(x => x.MemberId)
                    .NotEmpty().WithMessage("Boş Bırakılamaz.");
            RuleFor(x => x.BookId)
                    .NotEmpty().WithMessage("Boş Bırakılamaz.");

        }

            
    }
}
