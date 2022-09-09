using ExTaxes.Entities;

namespace ExTaxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Payer> payersList = new List<Payer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine()!);

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                
                Console.Write("Natural or company (n/c)? ");
                char cn = char.Parse(Console.ReadLine()!);

                Console.Write("Name: ");
                string name = Console.ReadLine()!;

                Console.Write("Anual income: ");
                double income = double.Parse(Console.ReadLine()!);
                
                if (cn == 'n' || cn == 'N')
                {
                    Console.Write("Health expenditures: ");
                    double expenditures = double.Parse(Console.ReadLine()!);

                    payersList.Add(new NaturalPayer(expenditures, name, income));
                }
                else
                {
                    Console.Write("Numer of employees: ");
                    int employees = int.Parse(Console.ReadLine()!);

                    payersList.Add(new LegalPayer(employees, name, income));
                }
            }

            double sum = 0;
            foreach (Payer payer in payersList)
            {
                Console.WriteLine("Taxes paid:");

                double t = payer.TotalTaxes();
                
                Console.WriteLine(payer.Name + " $ " + t);
                sum += t;    
            }
        }
    }

}