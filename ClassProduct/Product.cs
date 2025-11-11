using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProduct
{
    public class Product
    {
        public string Name {get; set;}                   // назва товару
        public CategoryTyp Category {get;}               // категорія (тільки get)
        public decimal Price {get; set;}                 // ціна
        public int Quantity {get; set;}                  // кількість
        public int Discount {get; set;}

        //конструктор
        public Product(string name, CategoryTyp category, decimal price, int stockQuantity, int discountPercentage)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = stockQuantity;
            Discount = discountPercentage;

        }
        //методи
        public decimal GetPriceWithDiscount()
        {
            decimal discountAmount = (Price * Discount) / 100;
            return Price - discountAmount;

        }
        public decimal TotalValue
        {
           get { return GetPriceWithDiscount() * Quantity; }
        }
        public void Sell(int quantity)
        {
            string massage;
            if (quantity < 0)
            {
                massage = "Quantity to sell cannot be negative.";
            }
            else if (quantity > Quantity)
            {
                massage = "Not enough stock to complete the sale.";
            }
            else
            {
                Quantity -= quantity;
                massage = $"Sold {quantity} units of {Name}. Remaining stock: {Quantity}";
            }
            Console.WriteLine(massage);
        }

        public void Restock(int quantity)
        {
            string massage;
            if (quantity > 0)
            {
                Quantity += quantity;
                massage = $"Restocked {quantity} units of {Name}. New stock: {Quantity}";
            }
            else
            {
                massage = "Restock quantity must be positive.";
            }
            Console.WriteLine(massage);
        }
       
        public void ShowInfo()
        {
            string info =     ($" Product Info:\n" +
                              $"- Name: {Name}\n" +
                              $"- Category: {Category}\n" +
                              $"- Price: {Price:C}\n" +
                              $"- Stock Quantity: {Quantity}\n" +
                              $"- Discount: {Discount}%\n" + 
                              $"- Price after Discount: {GetPriceWithDiscount():C}\n" +
                              $"- Total Value in Stock: {TotalValue:C}");
            Console.WriteLine(info);
        }
    }
}

