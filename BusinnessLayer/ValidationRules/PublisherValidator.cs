using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnessLayer.ValidationRules
{
    public class PublisherValidator:AbstractValidator<Publisher>
    {
        public PublisherValidator() 
        {
            RuleFor(x => x.Name)
                  .NotEmpty().WithMessage("Boş Bırakılamaz.")
                   .MaximumLength(50).WithMessage("50 Karakterden az olmalıdır.")
                   .MinimumLength(2).WithMessage("2 Karakterden fazla olmalıdır.");
        }
    }
}
