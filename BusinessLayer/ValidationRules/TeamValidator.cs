using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Personel adı boş bırakılamaz.");
            RuleFor(x => x.PersonName).MaximumLength(40).WithMessage("Ad - Soyad 40 karakteri geçemez.");
            RuleFor(x => x.PersonName).MinimumLength(4).WithMessage("Ad - Soyad 4 karakterden az olamaz.");
            RuleFor(x => x.PersonTitle).NotEmpty().WithMessage("Personel ünvanı boş bırakılamaz.");
            RuleFor(x => x.PersonTitle).MaximumLength(45).WithMessage("Ünvan 45 karakteri geçemez.");
            RuleFor(x => x.PersonTitle).MinimumLength(4).WithMessage("Ünvan 4 karakterden az olamaz.");
            RuleFor(x => x.PersonImageUrl).NotEmpty().WithMessage("Personel resmi boş bırakılamaz.");
        }
    }
}
