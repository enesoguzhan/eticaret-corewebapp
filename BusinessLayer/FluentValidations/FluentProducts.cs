using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class FluentProducts : AbstractValidator<Products>
    {
        public FluentProducts()
        {

        }
    }
}
