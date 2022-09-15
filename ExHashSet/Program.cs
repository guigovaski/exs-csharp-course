namespace ExHashSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> studentsCode = new HashSet<int>();

            Console.Write("How many students for course A? ");
            int a = int.Parse(Console.ReadLine());

            for (int i = 0; i < a; i++)
            {
                int code = int.Parse(Console.ReadLine());
                studentsCode.Add(code);
            }

            Console.Write("How many students for course B? ");
            int b = int.Parse(Console.ReadLine());

            for (int i = 0; i < b; i++)
            {
                int code = int.Parse(Console.ReadLine());
                studentsCode.Add(code);
            }

            Console.Write("How many students for course C? ");
            int c = int.Parse(Console.ReadLine());

            for (int i = 0; i < c; i++)
            {
                int code = int.Parse(Console.ReadLine());
                studentsCode.Add(code);
            }

            Console.Write("Total students: " + studentsCode.Count);
        }
    }
}
