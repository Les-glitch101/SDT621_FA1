using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunicipalityApp
{
    internal class Resident
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public double MonthlyUsage { get; set; }

        public Resident(string name, string address, string accountNumber, double monthlyUsage)
        {
            Name = name;
            Address = address;
            AccountNumber = accountNumber;
            MonthlyUsage = monthlyUsage;
        }

        public override string ToString()
        {
            return $"{Name} ({AccountNumber}) - {Address}, Usage: {MonthlyUsage}";
        }
    }
}
