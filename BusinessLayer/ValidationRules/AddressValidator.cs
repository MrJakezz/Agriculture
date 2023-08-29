using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.AddressDescription1).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.AddressDescription1).MaximumLength(25).WithMessage("Açıklama 25 karakterden fazla olamaz.");
            RuleFor(x => x.AddressDescription2).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.AddressDescription2).MaximumLength(25).WithMessage("Açıklama 25 karakterden fazla olamaz.");
            RuleFor(x => x.AddressDescription3).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.AddressDescription3).MaximumLength(25).WithMessage("Açıklama 25 karakterden fazla olamaz.");
            RuleFor(x => x.AddressDescription4).NotEmpty().WithMessage("Açıklama boş bırakılamaz.");
            RuleFor(x => x.AddressDescription4).MaximumLength(25).WithMessage("Açıklama 25 karakterden fazla olamaz.");

            RuleFor(x => x.AddressMapInfo).NotEmpty().WithMessage("Harita boş bırakılamaz.");
        }
    }
}
