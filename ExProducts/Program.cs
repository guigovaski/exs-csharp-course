using SectionTeen.Entities;
using System.Globalization;

namespace ExProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Product> productsList = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 1; i <= n; i++)
            {
                Console.Write("Common, used or imported (c/u/i)? ");
                char cui = char.Parse(Console.ReadLine()!);

                Console.Write("Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                
                if (cui == 'u' || cui == 'U')
                {
                    Console.Write("Manufacture date (DD/MM/YYY): ");
                    DateTime manufacture = DateTime.Parse(Console.ReadLine()!);

                    productsList.Add(new UsedProduct(name, price, manufacture));
                }
                else if (cui == 'i' || cui == 'I')
                {
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

                    productsList.Add(new ImportedProduct(name, price, customsFee));
                }
                else
                {
                    productsList.Add(new Product(name, price));
                }
            }

            foreach (Product product in productsList)
            {
                Console.WriteLine(product.PriceTag());
            }
        }
    }
}
