namespace TemperatureConverter
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a score between 0 and 100");
            string score = Console.ReadLine();

            if (int.TryParse(score, out int num))
            {
                if (num >= 0 && num <= 100)
                {
                    if (num >= 90) Console.WriteLine("Grade: A");
                    else if (num >= 80) Console.WriteLine("Grade: B");
                    else if (num >= 70) Console.WriteLine("Grade: C");
                    else if (num >= 60) Console.WriteLine("Grade: D");
                    else Console.WriteLine("Grade: F");
                }
                else Console.WriteLine("Score must be between 0 and 100.");
            }
            else
            {
                Console.WriteLine("Invalid text");

            }

        }
    }
}
