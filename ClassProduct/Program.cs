namespace ClassProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product normal = new Product("Laptop", CategoryTyp.Electronics, 2000m, 5);
            Console.WriteLine($"Normal Product Price: {normal.GetPrice()}");

            FastPerishableProduct perishable = new FastPerishableProduct("Milk", CategoryTyp.Fairy, 3m, 10, 1);
            FastPerishableProduct perishable2 = new FastPerishableProduct("Cheese", CategoryTyp.Fairy, 5m, 8, 3);
            FastPerishableProduct perishable3 = new FastPerishableProduct("Yogurt", CategoryTyp.Fairy, 2m, 15, 7);

            Console.WriteLine($"Fast Perishable Product (1 day to expire) Price: {perishable.GetPrice()}");
            Console.WriteLine($"Fast Perishable Product (3 days to expire) Price: {perishable2.GetPrice()}");
            Console.WriteLine($"Fast Perishable Product (7 days to expire) Price: {perishable3.GetPrice()}");

            ImportedProduct imported = new ImportedProduct("Banan", CategoryTyp.Fruits, 10m, 20);
            Console.WriteLine($"Imported Product Price: {imported.GetPrice()}");

            DiscountProduct discount = new DiscountProduct("TV", CategoryTyp.Electronics, 1500m, 3, 0.15m);
            Console.WriteLine($"Discount Product Price: {discount.GetPrice()}");

            PremiumProduct premium = new PremiumProduct("Smartphone", CategoryTyp.Electronics, 1000m, 7);
            Console.WriteLine($"Premium Product Price: {premium.GetPrice()}");

            Warehouse warehouse = new Warehouse("Main Warehouse");
            warehouse.AddProduct(normal);
            warehouse.AddProduct(perishable);
            warehouse.AddProduct(perishable2);
            warehouse.AddProduct(imported);
            warehouse.AddProduct(discount);
            warehouse.AddProduct(premium);

            Console.WriteLine($"Total amount in warehouse: {warehouse.GetTotalAmount()}");
            Console.WriteLine($"Total value in warehouse: {warehouse.GetTotalValue()}");

            Product found = warehouse.FindProduct("Cheese");
            if (found != null)
            {
                Console.WriteLine($"Found product: {found.Name} with price {found.GetPrice()}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            warehouse.DeleteProduct(2); // Deleting "Cheese"
            Console.WriteLine($"Total amount in warehouse after deletion: {warehouse.GetTotalAmount()}");
        }
    }
}
