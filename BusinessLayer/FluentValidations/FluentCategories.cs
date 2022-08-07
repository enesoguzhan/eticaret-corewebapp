using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class FluentCategories : AbstractValidator<Categories>
    {
        public FluentCategories()
        {
            RuleFor(s => s.Name).MinimumLength(3).WithMessage("Minimum 3 Karakter Girebilirsiniz.");
            RuleFor(s => s.Name).MaximumLength(50).WithMessage("Max 50 Karakter Girebilirsiniz.");
        }
    }
}
