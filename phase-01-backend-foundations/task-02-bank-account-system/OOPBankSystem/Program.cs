using OOPBankSystem.Models;
using OOPBankSystem.Services;
using OOPBankSystem.UI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;


BankAccount account = new BankAccount();

BankService bankService = new BankService();

ConsoleMenu consoleMenu = new ConsoleMenu();




bool lifetime = true;

while (lifetime)
{

    consoleMenu.Menu();
    if (!int.TryParse(Console.ReadLine(), out int input))
    {
        return;
    }

    switch (input)
    {
        case 1:
            Console.WriteLine("Enter Full Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter phone number");
            string phone = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)|| string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone)) { Console.WriteLine("Invalid Name or email or password"); return; }

            Console.WriteLine("Enter Initial Balance");
            if (!decimal.TryParse(Console.ReadLine(), out decimal b)|| b<0)
            {
                Console.WriteLine("Invalid Balance");
                return;
            }
            bankService.CreateAccount(name, email, phone, b);
            Console.WriteLine("\n");
            break;
        case 2:
            Console.WriteLine("Enter the amount to deposit");
            if (decimal.TryParse(Console.ReadLine(), out decimal a))

                account.Deposit(a);
            Console.WriteLine($"Succesful Deposit amount :{a}");
            break;

        case 3:
            Console.WriteLine("Enter the amount to Withdraw");
            if (decimal.TryParse(Console.ReadLine(), out decimal w))
                account.Withdraw(w);
            Console.WriteLine($"Succesful Withdr amount :{w}");
            break;

        case 4:
            Console.WriteLine("Enter the amount to deposit");


            if (!decimal.TryParse(Console.ReadLine(), out decimal t))
                Console.WriteLine("Enter your accountId");
            if (!int.TryParse(Console.ReadLine(), out int fromAcc))
                Console.WriteLine("Enter Transfer accountId");
            if (!int.TryParse(Console.ReadLine(), out int toAcc))
            {

            }

            if (bankService.Trasfer(fromAcc, toAcc, t))
            {
                Console.WriteLine("Transfer Successful!");
            }
            else Console.WriteLine("Transfer Failed (Check IDs or Balance)");
            break;

        case 5:
            Console.WriteLine("--- View Account Details ---");
            Console.Write("Enter Account Number: ");
            if (int.TryParse(Console.ReadLine(), out int accNo))
            {
                var accoun = bankService.GetAccountById(accNo);
                if (accoun != null)
                {
                    Console.WriteLine("Account Information:");
                    Console.WriteLine($"---------------------------");
                    Console.WriteLine($"Account Number: {accoun.AccountNumber}");
                    Console.WriteLine($"Full Name     : {accoun.Customer.FullName}");
                    Console.WriteLine($"Email         : {accoun.Customer.Email}");
                    Console.WriteLine($"Phone         : {accoun.Customer.Phone}");
                    Console.WriteLine($"Account Type  : {accoun.AccountType}");
                    Console.WriteLine($"Balance       : {accoun.Balance:C}");
                    Console.WriteLine($"Created At    : {accoun.CreatedAt:yyyy-MM-dd}");
                    Console.WriteLine($"Status        : {(accoun.IsActive ? "Active" : "Inactive")}");
                    Console.WriteLine($"---------------------------");
                }
                else
                {
                    Console.WriteLine("Error: Account not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric Account ID.");
            }
            break;

        case 6:
            Console.WriteLine("\n--- View Transaction History ---");
            Console.Write("Enter Account Number: ");

            if (int.TryParse(Console.ReadLine(), out int historyAccNo))
            {

                var acc = bankService.GetAccountById(historyAccNo);

                if (acc != null)
                {
                    if (acc.Transactions == null || acc.Transactions.Count == 0)
                    {
                        Console.WriteLine("No transactions found for this account.");
                    }
                    else
                    {
                        Console.WriteLine($"\nTransaction History for Account: {historyAccNo}");
                        Console.WriteLine("-----------------------------------------------------------------------------");
                        Console.WriteLine($"{"Type",-15} | {"Amount",-10} | {"Date",-20} | {"Balance After",-10}");
                        Console.WriteLine("-----------------------------------------------------------------------------");

                        var sortedTransactions = acc.Transactions.OrderByDescending(t => t.TransactionDate);

                        foreach (var tr in sortedTransactions)
                        {
                            Console.WriteLine($"{tr.TransactionType,-15} | {tr.Amount,-10:C} | {tr.TransactionDate,-20:yyyy-MM-dd HH:mm} | {tr.BalanceAfterTransaction,-10:C}");
                        }
                        Console.WriteLine("-----------------------------------------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Account not found.");
                }
            }
            break;

        case 7:

            Console.WriteLine("\n___________________________________________");
            var accountsList = bankService.GetAccounts();
            if (accountsList != null)
            {
                foreach (var acc in accountsList)
                {
                    Console.WriteLine($"Account Id :{acc.AccountNumber}");
                    Console.WriteLine($"Account Balance :{acc.Balance}");
                    Console.WriteLine($"Account Date :{acc.CreatedAt}");
                    Console.WriteLine("\n");
                    Console.WriteLine($"Account Name :{acc.Customer.FullName}");
                    Console.WriteLine($"Account Email :{acc.Customer.Email}");
                    Console.WriteLine($"Account Phone :{acc.Customer.Phone}");
                    Console.WriteLine("\n__  __ __ __ __ __ __ __ __ __");
                }
            }

            Console.WriteLine("No accounts yet");
            Console.WriteLine("\n___________________________________________");

            break;


        case 8:
            lifetime = false;
            break;

        default:
            break;
    }

}