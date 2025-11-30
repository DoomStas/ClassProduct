using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class ImportedProduct : Product
    {
        public ImportedProduct(string name, CategoryTyp category, decimal price, int amount)
            : base(name, category, price, amount)
        {
        }
        public override decimal GetPrice()
        {
            return base.GetPrice() * 1.05m; // 5% import duty
        }
    }
}
