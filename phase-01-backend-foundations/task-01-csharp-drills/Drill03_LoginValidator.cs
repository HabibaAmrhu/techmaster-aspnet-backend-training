namespace TemperatureConverter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string username = "admin";
            string password = "123";

            bool IsValid = false;

            int counter = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter your name");
                string user = Console.ReadLine().ToLower();
                Console.WriteLine("Enter your password");
                string pass = Console.ReadLine();
                if (user == username && pass == password)
                {
                    Console.WriteLine("Login successful");
                    IsValid = true;
                    return;
                }
                Console.WriteLine("Wrong username or password");
            }
            if (IsValid == false)
            {
                Console.WriteLine("Account locked. Too many failed attempts");
            }



        }
    }
}
