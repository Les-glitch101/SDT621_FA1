using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    internal class UtilitiesManager
    {
        private List<ServiceRequest> requests = new List<ServiceRequest>();

        public void AddRequest(ServiceRequest request)
        {
            // Urgency Score: Priority × Severity
            request.UrgencyScore = request.PriorityLevel * request.SeverityLevel * 2;

            // Household Impact Score: (Severity × MonthlyUsage) ÷ ResolutionHours
            request.HouseholdImpactScore = ((request.SeverityLevel * request.Resident.MonthlyUsage) / request.ResolutionHours) / 2;

            requests.Add(request);
        }

        public void ProcessRequests()
        {
            foreach (var req in requests)
            {
                Console.WriteLine("\n==== Service Report ====");
                Console.WriteLine($"Resident: {req.Resident.Name}");
                Console.WriteLine($"Service Type: {req.RequestType}");                
                Console.WriteLine($"Urgency Score: {req.UrgencyScore}");
                Console.WriteLine($"Adjusted Resolution: {req.ResolutionHours + 4 +" Hours"}");
                Console.WriteLine($"Household Impact Score: {req.HouseholdImpactScore:F2}");
            }
        }

        public void Summary()
        {
            Console.WriteLine("\n==== FINAL MUNICIPAL SUMMARY ====");
            if (requests.Count > 0)
            {
                var highest = requests.OrderByDescending(r => r.UrgencyScore).First();
                Console.WriteLine("Highest Priority Issue:");
                Console.WriteLine($"Resident: {highest.Resident.Name}");
                Console.WriteLine($"Service Type: {highest.RequestType}");
                Console.WriteLine($"Urgency Score: {highest.UrgencyScore}");
                Console.WriteLine($"Adjusted Resolution: {highest.ResolutionHours + 2 + " Hours"}");
                Console.WriteLine($"Household Impact Score: {highest.HouseholdImpactScore:F2}");
            }
        }
    }
    }
