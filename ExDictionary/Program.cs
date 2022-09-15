namespace ExDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> candidates = new Dictionary<string, int>();

            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();

            using StreamReader sr = File.OpenText(path);

            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(',');
                string name = line[0];
                int votes = int.Parse(line[1]);

                if (candidates.ContainsKey(name))
                {
                    candidates[name] += votes;
                }
                else
                {
                    candidates[name] = votes;
                }
            }

            foreach (var candidate in candidates)
            {
                Console.WriteLine($"{candidate.Key}: {candidate.Value}");
            }

        }
    }
}
