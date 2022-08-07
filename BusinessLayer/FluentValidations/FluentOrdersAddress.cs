using EntityLayer;
using FluentValidation;

namespace BusinessLayer.FluentValidations
{
    public class FluentOrdersAddress : AbstractValidator<OrderAddress>
    {
        public FluentOrdersAddress()
        {
            RuleFor(s => s.NameSurname).MinimumLength(1).WithMessage("Boş Olamaz").MaximumLength(100).WithMessage("Maximum 100 Karakter Girilebilir");
            RuleFor(s => s.Phone).MinimumLength(1).WithMessage("Boş Olamaz").MaximumLength(100).WithMessage("Maximum 20 Karakter Girilebilir");
            RuleFor(s => s.City).MinimumLength(1).WithMessage("Boş Olamaz").MaximumLength(100).WithMessage("Maximum 50 Karakter Girilebilir");
            RuleFor(s => s.District).MinimumLength(1).WithMessage("Boş Olamaz").MaximumLength(100).WithMessage("Maximum 50 Karakter Girilebilir");
        }
    }
}
