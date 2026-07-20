using NHibernate.Mapping;

namespace TemperatureConverter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            decimal balance = 1000;
            Console.WriteLine("how many items");
            bool lifetime = true;

            while (lifetime)
            {
                Console.WriteLine("\n--- ATM Menu ---");
                Console.WriteLine("1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Your current balance is: {balance:C}");

                        break;

                    case "2":
                        Console.Write("Enter Withdraw amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal deposit) && deposit > 0)
                        {
                            balance += deposit;
                            Console.WriteLine("Deposit successful.");
                        }
                        else Console.WriteLine("Invalid amount. Deposit must be positive.");
                        break;

                    case "3":
                        if (decimal.TryParse(Console.ReadLine(), out decimal with) && with > 0)
                        {
                            balance -= with;
                            Console.WriteLine("Withdraw successful.");
                        }
                        else Console.WriteLine("Invalid amount. Deposit must be positive.");
                        break;

                    case "4":
                        lifetime = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;




                }


            }


        }
    }
}
