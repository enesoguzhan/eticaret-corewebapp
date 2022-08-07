using EntityLayer;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidations
{
    public class FluentProducts : AbstractValidator<Products>
    {
        public FluentProducts()
        {
            RuleFor(s => s.Name).MinimumLength(1).WithMessage("Boş Bırakılamaz").MaximumLength(100).WithMessage("Maximum 100 Karakter Girilebilir.");
            RuleFor(s => s.Explanation).MinimumLength(1).WithMessage("Boş Bırakılamaz");
            RuleFor(s => s.Price).Must(SayiKontrol).WithMessage("Minimum 1 ve Maximum 999999 Arasında stok girilebilir").When(s => s.Stock < 1).WithMessage("Minimum 1 ve Maximum 999999 Arasında stok girilebilir");
            RuleFor(s => s.Stock).Must(StokKontrol).WithMessage("Minimum 1 ve Maximum 999 Arasında stok girilebilir").When(s => s.Stock < 1).WithMessage("Minimum 1 ve Maximum 999 Arasında stok girilebilir");
        }

        private bool SayiKontrol(decimal price)
        {
            // Girilen veri kesinlikle sayı olmalı ve Max 6 haneli olamalıdır
            Regex regex = new Regex(@"\d{6}");

            return regex.IsMatch(price.ToString());
        }
        private bool StokKontrol(int stock)
        {
            // Girilen veri kesinlikle sayı olmalı ve Max 6 haneli olamalıdır
            Regex regex = new Regex(@"\d{6}");

            return regex.IsMatch(stock.ToString());
        }
    }
}
