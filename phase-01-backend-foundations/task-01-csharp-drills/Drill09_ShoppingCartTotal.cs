using NHibernate.Mapping;

namespace TemperatureConverter
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("how many items");
            string pass = Console.ReadLine();
            if (!int.TryParse(pass, out int nItems) || nItems<0)
            {
                Console.WriteLine("Invalid number of items.");
                return;
            }
            decimal total = 0;

            for (int i = 0; i < nItems; i++)
            {
                Console.Write("Enter Price: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price)|| price<=0)
                {
                    Console.WriteLine("Invalid price\r\n");
                }
                Console.Write("Enter Quantity: ");
                if (!int.TryParse(Console.ReadLine(), out int quantity)|| quantity <=0) Console.WriteLine("Invalid quantity\r\n");

                total += price* quantity;
            }
            decimal discount = 0;
            if (total >1000)
            {
                discount = total * 0.10m;
                decimal final = total -discount;
                Console.WriteLine($"{total} discount: {discount} , final {final}");
            }
            else
            {
                Console.WriteLine("no discount\r\n");
            }


        }
    }
}
