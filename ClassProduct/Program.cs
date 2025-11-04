namespace ClassProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Laptop", CategoryTyp.electronics, 1500.00m, 10, 15);
            Console.WriteLine($"Product: {product.GetPriceWithDiscount():C} after discount");
            Console.WriteLine($"Total value in stock: {product.TotalValue():C}");

            product.Sell(3);
            product.Restock(5);
            product.ChangePrice(1400.00m);
            product.SetDiscount(20);
            product.ShowInfo();
        }
    }
}
