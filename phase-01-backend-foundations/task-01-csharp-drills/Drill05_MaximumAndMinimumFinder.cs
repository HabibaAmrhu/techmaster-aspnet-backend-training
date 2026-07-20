using System.Numerics;

namespace TemperatureConverter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (!int.TryParse(Console.ReadLine(), out int c) || c <= 0)
            {
                Console.WriteLine("Count Must be positive");
                return;
            }
            List<int> nums = new List<int>();
            for (int i = 0; i < c; i++)
            {
                if (int.TryParse(Console.ReadLine(), out int n))
                    nums.Add(n);
            }
            int max = nums[0];
            int min = nums[0];

            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > max) { max = nums[i]; }
                if (nums[i] < min) { min = nums[i]; }
            }
            Console.Write($"Max: {max} | Min: {min}");
        }
    }
}
