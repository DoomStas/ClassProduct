namespace ClassProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Laptop", CategoryTyp.Electronics, 1500.00m, 10, 15);
            Console.WriteLine($"Product: {product.GetPriceWithDiscount():C} after discount");
            Console.WriteLine($"Total value in stock: {product.TotalValue:C}");
            Console.WriteLine();

            Console.WriteLine(product.Sell(3));
            Console.WriteLine(product.Restock(5));
            Console.WriteLine();

            product.Price = 1400.00m; // Update price
            Console.WriteLine ($"Updated Price: {product.Price:C}");

            product.Discount = 10; // Update discount
            Console.WriteLine($"Updated Price after new discount: {product.GetPriceWithDiscount():C}");

            Console.WriteLine(product.AddReview("Great product!"));
            Console.WriteLine(product.AddReview("Good value for money."));
            Console.WriteLine(product.AddReview("Would buy again."));
            Console.WriteLine();

            Console.WriteLine("=== Reviews ===");
            foreach (var review in product.ShowReviews())
            Console.WriteLine(review);
            Console.WriteLine();

            Console.WriteLine(product.UpdateReview(1, "Excellent value for money."));
            Console.WriteLine(product.DeleteReview(2));
            Console.WriteLine();

            Console.WriteLine("=== Reviews after update/delete ===");
            foreach (var review in product.ShowReviews())
            Console.WriteLine(review);
            Console.WriteLine();

            Console.WriteLine(product[0]); // Access review by index
            Console.WriteLine(product[1]);
            product[0] = "Updated review via indexer.";
            Console.WriteLine();

            Console.WriteLine("=== Reviews for index ===");
            foreach (var review in product.ShowReviews())
            Console.WriteLine(review);
            Console.WriteLine();

            Console.WriteLine(product.ShowInfo());
        }
    }
}
