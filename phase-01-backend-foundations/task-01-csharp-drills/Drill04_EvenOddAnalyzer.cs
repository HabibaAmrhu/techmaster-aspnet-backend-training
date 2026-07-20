using System.Numerics;

namespace TemperatureConverter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("How many numbers will you enter? ");
            if (!int.TryParse(Console.ReadLine(), out int c) ||c<=0)
            {
                Console.WriteLine("Count must be a positive integer.");
                return;
            }

            List<int> even = new List<int>();
            List<int> odd = new List<int>();



            for (int i = 0; i < c; i++)
            {
                if (int.TryParse(Console.ReadLine(), out int e))
                {
                    if(e % 2 == 0) even.Add(e);
                    else odd.Add(e);
                }
            }

            if (even.Count > 0)
                Console.WriteLine($"Even: {string.Join(",", even)}");
            else
                Console.WriteLine("Even list is empty.");

            if (odd.Count > 0)
                Console.WriteLine($"Odd: {string.Join(",", odd)}");
            else
                Console.WriteLine("Odd list is empty.");
        }
    }
}
