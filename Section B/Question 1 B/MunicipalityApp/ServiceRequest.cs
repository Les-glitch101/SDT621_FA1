using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    internal class ServiceRequest
    {
        public Resident Resident { get; set; }
        public string RequestType { get; set; }
        public int PriorityLevel { get; set; }   // 1–5
        public int SeverityLevel { get; set; }   // 1–10
        public int ResolutionHours { get; set; }
        public double UrgencyScore { get; set; }
        public double HouseholdImpactScore { get; set; }


        public ServiceRequest(Resident resident, string requestType, int priority, int severity, int resolutionHours)
        {
            Resident = resident;
            RequestType = requestType;
            PriorityLevel = priority;
            SeverityLevel = severity;
            ResolutionHours = resolutionHours;
        }

        public override string ToString()
        {
            return $"Resident: {Resident.Name}, Request: {RequestType}, Priority: {PriorityLevel}, Severity: {SeverityLevel}, Resolution: {ResolutionHours}h, Urgency: {UrgencyScore:F2}";
        }
    }
}
