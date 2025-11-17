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

        private string[] reviews;
        private int reviewCount;

        //конструктор
        public Product(string name, CategoryTyp category, decimal price, int stockQuantity, int discountPercentage)
        {
            Name = name;
            Category = category;
            Price = price;
            Quantity = stockQuantity;
            Discount = discountPercentage;
            reviews = new string[20];
            reviewCount = 0;

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
        public string Sell(int quantity)
        {
            string message;
            if (quantity < 0)
            {
                return "Quantity to sell cannot be negative.";
            }
            else if (quantity > Quantity)
            {
                return "Not enough stock to complete the sale.";
            }
            else
            {
                Quantity -= quantity;
                return $"Sold {quantity} units of {Name}. Remaining stock: {Quantity}";
            }
            
        }

        public string Restock(int quantity)
        {
            
            if (quantity > 0)
            {
                Quantity += quantity;
                return $"Restocked {quantity} units of {Name}. New stock: {Quantity}";
            }
            else
            {
                return "Restock quantity must be positive.";
            }
           
        }

        private void ResizeReviewsArray()
        {
            string[] newReviews = new string[reviews.Length * 2];
            for (int i = 0; i < reviews.Length; i++)
            {
                newReviews[i] = reviews[i];
            }
            reviews = newReviews;
        }

        //create
        public string AddReview(string review)
        {
            if (reviewCount >= reviews.Length)
            {
                ResizeReviewsArray();

            }
            reviews[reviewCount] = review;
            reviewCount++;
            return"Review added successfully.";

        }

        //read
        public string[] ShowReviews()
        {
            string[] result = new string[reviewCount];
            for (int i = 0; i < reviewCount; i++)
                result[i] = reviews[i];

            return result;
        }

        //update
        public string UpdateReview(int index, string newReview)
        {
            if (index < 0 || index >= reviewCount)
            {
                return"Invalid review index.";
                
            }
            reviews[index] = newReview;
            return"Review updated successfully.";
        }
        //delete
        public string DeleteReview(int index)
        {
            if (index < 0 || index >= reviewCount)
            {
                return "Invalid review index.";
                
            }
            for (int i = index; i < reviewCount - 1; i++)
            {
                reviews[i] = reviews[i + 1];
            }
            reviews[reviewCount - 1] = null;
            reviewCount--;
            return "Review deleted successfully.";
        }

        //index
        public string this[int index]
        {
            get
            {
                if (index < 0 || index >= reviewCount)
                {
                    return "Invalid review index.";
                }
                return reviews[index];
            }
            set
            {
                if (index < 0 || index >= reviewCount)
                {
                    throw new IndexOutOfRangeException("Invalid review index.");
                }
                reviews[index] = value;
            }
        }

        public string ShowInfo()
        {
            return    $" Product Info:\n" +
                              $"- Name: {Name}\n" +
                              $"- Category: {Category}\n" +
                              $"- Price: {Price:C}\n" +
                              $"- Stock Quantity: {Quantity}\n" +
                              $"- Discount: {Discount}%\n" + 
                              $"- Price after Discount: {GetPriceWithDiscount():C}\n" +
                              $"- Total Value in Stock: {TotalValue:C}";
            
        }
    }
}

