using System.Globalization;
using ExPayment.Entities;
using ExPayment.Services;

namespace ExPayment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data:");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Date: (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Contract value: ");
            double totalValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.Write("Enter number of installments: ");
            int n = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, totalValue, n, new PaypalService());

            Console.WriteLine("Installments:");
            Console.WriteLine(contract.ToString());

        }
    }
}

