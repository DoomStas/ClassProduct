using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class FastPerishableProduct : Product
    {
        private int _daysToExpire;
        public FastPerishableProduct(string name, CategoryTyp category, decimal price, int amount, int daysToExpire)
            : base(name, category, price, amount)
        {
            _daysToExpire = daysToExpire;
        }

        public override decimal GetPrice()
        {
            decimal basePrice = base.GetPrice();

            if (_daysToExpire <= 1)
            {
                return basePrice * 0.5m; // 50% discount
            }
            else if (_daysToExpire <= 3)
            {
                return basePrice * 0.8m; // 20% discount
            }
            return basePrice;
        }
    }
}
