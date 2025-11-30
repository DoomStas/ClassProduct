using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class PremiumProduct : Product
    {
        public PremiumProduct(string name, CategoryTyp category, decimal price, int amount)
            : base(name, category, price, amount)
        {
        }
        public override decimal GetPrice()
        {
            return base.GetPrice() * 1.10m; // 20% premium surcharge
        }
    }
    
    
}
