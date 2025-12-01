using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    
    public class FastPerishableProduct : Product
    {
        private int _daysLeft;
        
        public FastPerishableProduct(string name, CategoryTyp category, decimal price, int amount, int daysLeft)
            : base(name, category, price, amount)
        {
            _daysLeft = daysLeft;
        }

        public void DecreaseDays(int days = 1)
        {
            if (days > 0)
            {
                _daysLeft -= days;
                if (_daysLeft < 0)
                {
                    _daysLeft = 0;
                }
            }
        }

        public override decimal GetPrice()
        {
            decimal basePrice = base.GetPrice();

            if (_daysLeft <= 1)
            {
                return basePrice * 0.5m; // 50% discount
            }
            else if (_daysLeft <= 3)
            {
                return basePrice * 0.8m; // 20% discount
            }
            return basePrice;
        }
        
    }
}
