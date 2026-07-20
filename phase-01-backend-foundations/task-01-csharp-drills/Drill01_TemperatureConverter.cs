namespace TemperatureConverter
{
    internal class Program
    {
        public static double Fahrenheit(double num)
        {
            return ((num * 9 / 5)+32);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number by degree celsius");
            string val = Console.ReadLine();

            if (double.TryParse(val ,out double num))
            {
                Console.WriteLine($"{val}┬░C = {Fahrenheit(num):F2} ┬░F");
            }
            else
            {
                Console.WriteLine("Invalid temperature value.");
            }
        }
    }
}
