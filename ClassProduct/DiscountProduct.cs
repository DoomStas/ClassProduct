using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class DiscountProduct : Product
    {

        private decimal _discountPercent;
        public DiscountProduct(string name, CategoryTyp category, decimal price, int amount, decimal discountPercent)
            : base(name, category, price, amount)
        {
            _discountPercent = discountPercent;
        }
        public override decimal GetPrice()
        {
            return base.GetPrice() * (1 - _discountPercent);
        }
    }
}
