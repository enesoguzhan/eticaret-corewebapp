using EntityLayer;
using FluentValidation;

namespace BusinessLayer.FluentValidations
{
    public class FluentCustomers : AbstractValidator<Customers>
    {
        public FluentCustomers()
        {
            RuleFor(s => s.NameSurname).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.NameSurname).MaximumLength(100).WithMessage("Max 100 Karakter girilebilir");

            RuleFor(s => s.Email).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Email).MaximumLength(100).WithMessage("Max 50 Karakter girilebilir");

            RuleFor(s => s.Phone).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Phone).MaximumLength(100).WithMessage("Max 20 Karakter girilebilir");

            RuleFor(s => s.Password).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Password).MaximumLength(100).WithMessage("Max 20 Karakter girilebilir");

        }
    }
}
