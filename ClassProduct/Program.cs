namespace ClassProduct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product1 = new Product("Laptop", CategoryTyp.Electronics, 1200.00m, 10);
            Product product2 = new Product("Apple", CategoryTyp.Fruits, 1.50m, 100);

            product1.AddReview("Great performance!");
            product2.AddReview("Very fresh and tasty.");

            Console.WriteLine("Reviews");
            foreach (var review in product1.GetReviews())
            {
                Console.WriteLine($"Product 1 Review: {review}");
            }

            Warehouse warehouse = new Warehouse("Main Warehouse");
            warehouse.AddProduct(product1);
            warehouse.AddProduct(product2);

            Console.WriteLine($"Total amount in warehouse: {warehouse.GetTotalAmount()}");
            Console.WriteLine($"Total value in warehouse: {warehouse.GetTotalValue()}");
            
            Product found = warehouse.FindProduct("Apple");
            if (found != null)
            {
                Console.WriteLine($"Found product: {found.Name} in category {found.Category}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }

            warehouse.DeleteProduct(0);
            Console.WriteLine($"Total amount in warehouse after deletion: {warehouse.GetTotalAmount()}");
        }
    }
}
