using ExLinq.Entities;

namespace ExLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();

            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine());

            using StreamReader sr = File.OpenText(path);
            
            while (!sr.EndOfStream)
            {
                string[] fields = sr.ReadLine().Split(',');
                string name = fields[0];
                string email = fields[1];
                double s = double.Parse(fields[2]);
                list.Add(new Employee(name, email, s));
            }

            var emails = list.Where(x => x.Salary > salary).Select(x => x.Email).OrderByDescending(x => x);

            Console.Write("Enter first letter of a name for get salarys");
            char letter = char.Parse(Console.ReadLine());
            var salarysAvg =
                (from e in list
                 where e.Name[0] == letter
                 select e.Salary).Average();

            Console.WriteLine($"E-mail of people whose salary is more than {salary}:");
            foreach (string e in emails)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine();
            Console.Write($"Sum of salary of people whose name starts {letter}: ");
            Console.WriteLine(salarysAvg);
        }
    }
}
