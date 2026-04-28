using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== Welcome to Emfuleni Municipality Service Desk ====");

            List<Resident> residents = new List<Resident>();
            UtilitiesManager manager = new UtilitiesManager();

            // Register residents
            Console.Write("How many residents do you want to register? ");
            int numResidents = int.Parse(Console.ReadLine());

            for (int i = 0; i < numResidents; i++)
            {
                Console.WriteLine($"\n---- Resident {i + 1} ----");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Address: ");
                string address = Console.ReadLine();
                Console.Write("Account Number: ");
                string accountNumber = Console.ReadLine();
                Console.Write("Monthly Utility Usage (kWh or Litres): ");
                double usage = double.Parse(Console.ReadLine());

                residents.Add(new Resident(name, address, accountNumber, usage));
            }

            // Log service requests
            Console.Write("\nHow many service requests do you want to log? ");
            int numRequests = int.Parse(Console.ReadLine());

            for (int i = 0; i < numRequests; i++)
            {
                Console.WriteLine($"\n---- Service Request {i + 1} ----");
                Console.Write($"Select Resident by number (1 to {residents.Count}): ");
                int resIndex = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Request Type (e.g. Water Outage, Burst Pipe): ");
                string type = Console.ReadLine();

                Console.Write("Priority Level (1-5): ");
                int priority = int.Parse(Console.ReadLine());

                Console.Write("Severity Level (1-10): ");
                int severity = int.Parse(Console.ReadLine());

                Console.Write("Estimated Resolution Hours: ");
                int hours = int.Parse(Console.ReadLine());

                ServiceRequest request = new ServiceRequest(residents[resIndex], type, priority, severity, hours);
                manager.AddRequest(request);
            }

            // Process and summarize
            manager.ProcessRequests();
            manager.Summary();

            Console.WriteLine("\nThank you for using the Emfuleni Municipality Service Desk.");
    }
    }
}
