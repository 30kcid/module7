using System;
using System.Collections.Generic; // Added by Erik Hernandez

namespace ContractorProject
{
    // Base Class
    public class Contractor
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public DateTime StartDate { get; set; }

        public Contractor() { }

        public Contractor(string name, int number, DateTime startDate)
        {
            Name = name;
            Number = number;
            StartDate = startDate;
        }
    }

    // Subclass
    public class Subcontractor : Contractor
    {
        public int Shift { get; set; }          // 1 = Day, 2 = Night
        public double HourlyRate { get; set; }  // pay rate

        public Subcontractor() { }

        public Subcontractor(string name, int number, DateTime startDate,
                             int shift, double hourlyRate)
            : base(name, number, startDate)
        {
            Shift = shift;
            HourlyRate = hourlyRate;
        }

        // Added by Erik Hernandez
        public string ShiftName
        {
            get { return Shift == 1 ? "Day" : "Night"; }
        }

        // Added by Erik Hernandez
        public override string ToString()
        {
            return $"Name: {Name}\n" +
                   $"Number: {Number}\n" +
                   $"Start Date: {StartDate:d}\n" +
                   $"Shift: {ShiftName}\n" +
                   $"Hourly Rate: {HourlyRate:C}";
        }

        // Pay method with 3% night shift differential
        public float CalculatePay(double hours)
        {
            double pay = hours * HourlyRate;

            if (Shift == 2)  // night shift
            {
                pay *= 1.03; // add 3%
            }

            return (float)pay;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---Contractor Project---\n"); // Added by Erik Hernandez

            List<Subcontractor> subcontractors = new List<Subcontractor>(); // Added by Erik Hernandez
            string again;                                                   // Added by Erik Hernandez

            do
            {
                Console.WriteLine("Enter Contractor Name:");
                string name = Console.ReadLine();

               Console.WriteLine("Enter Contractor Number:");
int number;  // declare first

while (!int.TryParse(Console.ReadLine(), out number))  
{
    Console.WriteLine("Invalid number. Please enter a whole number:"); // Added by Edwin Alfaro
}


                Console.WriteLine("Enter Start Date (MM/DD/YYYY):");
DateTime date;

while (!DateTime.TryParse(Console.ReadLine(), out date))
{
    Console.WriteLine("Invalid date. Enter again (MM/DD/YYYY):");  // Added by Edwin Alfaro
}


                Console.WriteLine("Enter Shift (1 = Day, 2 = Night):");
int shift;
while (!int.TryParse(Console.ReadLine(), out shift) || (shift != 1 && shift != 2))
{
    Console.WriteLine("Invalid shift. Enter 1 for Day or 2 for Night:");  // Added by Edwin Alfaro
}


                Console.WriteLine("Enter Hourly Rate:");
                double rate = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Hours Worked:");
                double hours = double.Parse(Console.ReadLine());

                // Create object
                Subcontractor s = new Subcontractor(name, number, date, shift, rate);

                float totalPay = s.CalculatePay(hours);

                subcontractors.Add(s); // Added by Erik Hernandez

                Console.WriteLine();
                Console.WriteLine("----- Subcontractor Info -----");
                Console.WriteLine(s.ToString());            // Added by Erik Hernandez
                Console.WriteLine($"Hours Worked: {hours}");// Added by Erik Hernandez
                Console.WriteLine($"Total Pay: {totalPay:C}");

                Console.WriteLine("\nDo you want to enter another subcontractor? (y/n)"); // Added by Erik Hernandez
                again = Console.ReadLine();                                                    // Added by Erik Hernandez
                Console.WriteLine();

            } while (again.Equals("y", StringComparison.OrdinalIgnoreCase)); // Added by Erik Hernandez

            Console.WriteLine($"Total subcontractors created: {subcontractors.Count}"); // Added by Erik Hernandez
        }
    }
}
