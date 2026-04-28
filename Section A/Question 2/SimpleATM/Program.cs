using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== CTU SIMPLE ATM SYSTEM =====");

            // Ask for user name
            Console.Write("HI, WHAT IS YOUR NAME? ");
            string userName = Console.ReadLine();

            Console.WriteLine($"\nWELCOME {userName.ToUpper()}!");

            // Get account balance
            decimal accountBalance = 0;
            while (true)
            {
                Console.Write("Enter account balance: ");
                string inputBalance = Console.ReadLine();

                if (decimal.TryParse(inputBalance, out accountBalance) && accountBalance >= 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric balance.");
                }
            }

            // Get withdrawal amount
            decimal withdrawalAmount = 0;
            while (true)
            {
                Console.Write("Enter withdrawal amount: ");
                string inputWithdrawal = Console.ReadLine();

                if (decimal.TryParse(inputWithdrawal, out withdrawalAmount) && withdrawalAmount > 0)
                {
                    if (withdrawalAmount <= accountBalance)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Withdrawal amount exceeds account balance. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid numeric withdrawal amount.");
                }
            }

            // Perform withdrawal
            accountBalance -= withdrawalAmount;

            // Display transaction results
            Console.WriteLine("\nWithdrawal successful!");
            Console.WriteLine($"Updated Balance: {accountBalance:N2}");
            Console.WriteLine($"Transaction Time: {DateTime.Now:dd MMM yyyy HH:mm:ss}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
    }
    }
}
