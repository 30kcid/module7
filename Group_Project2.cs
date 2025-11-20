using System;

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
            Console.WriteLine("Enter Contractor Name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Contractor Number:");
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Start Date (MM/DD/YYYY):");
            DateTime date = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Shift (1 = Day, 2 = Night):");
            int shift = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Hourly Rate:");
            double rate = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Hours Worked:");
            double hours = double.Parse(Console.ReadLine());

            // Create object
            Subcontractor s = new Subcontractor(name, number, date, shift, rate);

            float totalPay = s.CalculatePay(hours);

            Console.WriteLine();
            Console.WriteLine("----- Subcontractor Info -----");
            Console.WriteLine($"Name: {s.Name}");
            Console.WriteLine($"Number: {s.Number}");
            Console.WriteLine($"Start Date: {s.StartDate:d}");
            Console.WriteLine($"Shift: {(s.Shift == 1 ? "Day" : "Night")}");
            Console.WriteLine($"Hourly Rate: {s.HourlyRate}");
            Console.WriteLine($"Total Pay: {totalPay:C}");
        }
    }
}

