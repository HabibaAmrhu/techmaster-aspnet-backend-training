using System.Numerics;

namespace TemperatureConverter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a password");
            string pass = Console.ReadLine();

            if (pass.Count() < 8)
            {
                Console.WriteLine("password must be at least 8 characters");
                return;
            }

            bool IsUpper = false;
            bool IsLower = false;
            bool IsDigit = false;
            bool IsChar = false;
            for (int i = 0; i < pass.Count(); i++)
            {
                if (char.IsDigit(pass[i])) IsDigit = true;
                if (char.IsUpper(pass[i])) IsUpper = true;
                if (char.IsLower(pass[i])) IsLower = true;
                if (!char.IsUpper(pass[i]) &&!char.IsLower(pass[i]) && !char.IsDigit(pass[i])) IsChar = true;

            }

             List<string> missingRules = new List<string>();

            if (!IsUpper) missingRules.Add("UpperCase");
            if (!IsLower) missingRules.Add("LowerCase");
            if (!IsDigit) missingRules.Add("digit");
            if (!IsChar) missingRules.Add("special character");

            if (missingRules.Count()==0) { Console.WriteLine("Strong"); }
            else
            {
                Console.WriteLine($"Weak - missing {string.Join(", ", missingRules)}");
            }
        }
    }
}
