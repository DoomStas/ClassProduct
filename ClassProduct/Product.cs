using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class Product
    {
        private string _name;
        private CategoryTyp _category;
        private decimal _price;
        private int _stockQuantity;
        private int _discountPercentage;

        //конструктор
        public Product(string name, CategoryTyp category, decimal price, int stockQuantity, int discountPercentage)
        {
            _name = name;
            _category = category;
            _price = price;
            _stockQuantity = stockQuantity;
            _discountPercentage = discountPercentage;

        }
        //методи
        public decimal GetPriceWithDiscount()
        {
            decimal discountAmount = (_price * _discountPercentage) / 100;
            return _price - discountAmount;

        }
        public decimal TotalValue()
        {
            return GetPriceWithDiscount() * _stockQuantity;
        }
        public void Sell(int quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine("Quantity to sell cannot be negative.");
                return;
            }
            if (quantity > _stockQuantity)
            {
                Console.WriteLine("Not enough stock to complete the sale.");
            }
            else
            {
                _stockQuantity -= quantity;
                Console.WriteLine($"Sold {quantity} units of {_name}. Remaining stock: {_stockQuantity}");
            }
        }

        public void Restock(int quantity)
        {
            if (quantity > 0)
            {
                _stockQuantity += quantity;
                Console.WriteLine($"Restocked {quantity} units of {_name}. New stock: {_stockQuantity}");
            }
            else
            {
                Console.WriteLine("Restock quantity must be positive.");
            }
        }
        public void ChangePrice(decimal newPrice)
        {
            _price = newPrice;
            Console.WriteLine($"Price of {_name} changed to: {_price:C}");
        }
        public void SetDiscount(int newDiscount)
        {
            _discountPercentage = newDiscount;
            Console.WriteLine($"Discount for {_name} set to: {_discountPercentage}%");
        }
        public void ShowInfo()
        {
            Console.WriteLine($" Product Info:\n" +
                              $"- Name: {_name}\n" +
                              $"- Category: {_category}\n" +
                              $"- Price: {_price:C}\n" +
                              $"- Stock Quantity: {_stockQuantity}\n" +
                              $"- Discount: {_discountPercentage}%");
        }
    }
}

