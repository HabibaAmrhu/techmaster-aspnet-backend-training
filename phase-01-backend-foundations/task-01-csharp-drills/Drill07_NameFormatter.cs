using System.Numerics;

namespace TemperatureConverter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentense");
            string sen = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(sen))
            {
                Console.WriteLine("Sentence cannot be empty.");
                return;
            }
            string[] words = sen.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine($"Word count:{words.Count()}");
        }
    }
}
