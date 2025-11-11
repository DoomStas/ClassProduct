namespace ClassProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Laptop", CategoryTyp.Electronics, 1500.00m, 10, 15);
            Console.WriteLine($"Product: {product.GetPriceWithDiscount():C} after discount");
            Console.WriteLine($"Total value in stock: {product.TotalValue:C}");

            product.Sell(3);
            product.Restock(5);

            product.Price = 1400.00m; // Update price
            Console.WriteLine ($"Updated Price: {product.Price:C}");

            product.Discount = 10; // Update discount
            Console.WriteLine($"Updated Price after new discount: {product.GetPriceWithDiscount():C}");

            product.ShowInfo();
        }
    }
}
