using System.Globalization;

namespace ExFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string src = @"D:\guilh\file.csv";
            string target = @"D:\guilh\out";

            try
            {


                string[] file = File.ReadAllLines(src);

                Directory.CreateDirectory(target);

                using StreamWriter sr = File.AppendText(target + @"\summary.csv");

                foreach (string line in file)
                {
                    string[] parts = line.Split(",");
                    double total = double.Parse(parts[1]) * double.Parse(parts[2]);

                    sr.WriteLine($"{parts[0]},{total.ToString("F2", CultureInfo.InvariantCulture)}");
                }
            }
            catch (IOException e)
            {
                Console.Write("Error: " + e.Message);
            }
        }
    }

}
