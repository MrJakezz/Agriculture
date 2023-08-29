using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.ImageTitle).NotEmpty().WithMessage("Görsel başlığı boş geçilemez.");
            RuleFor(x => x.ImageDescription).NotEmpty().WithMessage("Görsel açıklaması boş geçilemez.");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel URL'si boş geçilemez.");
            RuleFor(x => x.ImageTitle).MaximumLength(20).WithMessage("Başlık en fazla 20 karakter olabilir.");
            RuleFor(x => x.ImageDescription).MaximumLength(50).WithMessage("Açıklama en fazla 50 karakter olabilir.");
        }
    }
}
