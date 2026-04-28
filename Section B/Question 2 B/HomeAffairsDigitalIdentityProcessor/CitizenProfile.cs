using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeAffairsDigitalIdentityProcessor
{
    internal class CitizenProfile
    {
        //getters and setters
        public string FullName { get; set; }
        public string IDNumber { get; set; }
        public int Age { get; set; }
        public string CitizenshipStatus { get; set; }

        //constructor to initialize the citizen profile with name,
        //ID number, and citizenship status. It also calculates the age based on the ID number.
        public CitizenProfile(string name, string id, string status)
        {
            FullName = name;
            IDNumber = id;
            CitizenshipStatus = status;
            Age = CalculateAge();
        }

        // This method extracts the birth date from the ID number and calculates the age of
        // the citizen. It handles potential errors in date parsing and returns -1 if the date is invalid.
        private int CalculateAge()
        {
            try
            {
                string yearPart = IDNumber.Substring(0, 2);
                string monthPart = IDNumber.Substring(2, 2);
                string dayPart = IDNumber.Substring(4, 2);

                int year = int.Parse(yearPart);
                int month = int.Parse(monthPart);
                int day = int.Parse(dayPart);

                // Determine century
                int fullYear = (year <= DateTime.Now.Year % 100) ? 2000 + year : 1900 + year;

                DateTime birthDate = new DateTime(fullYear, month, day);
                int age = DateTime.Now.Year - birthDate.Year;

                if (DateTime.Now < birthDate.AddYears(age))
                    age--;

                return age;
            }
            catch
            {
                return -1; // invalid date
            }
        }

        // This method validates the ID number by checking its length,
        // ensuring it is numeric, and verifying that the birth date is
        // valid. It returns a message indicating whether the ID is valid or what specific issue was found.
        public string ValidateID()
        {
            if (IDNumber.Length != 13)
                return "Invalid ID: Must be 13 digits." + IDNumber.Length;

            if (!long.TryParse(IDNumber, out _))
                return "Invalid ID: Must be numeric.";

            if (Age < 0)
                return "Invalid ID: Birth date is incorrect.";

            return $"Valid ID. Citizen is {Age} years old.";
        }
    }
}
