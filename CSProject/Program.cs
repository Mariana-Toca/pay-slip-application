using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{        
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff;
            FileReader fr = new FileReader();
            int month = 0;
            int year = 0;

            while (year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }

                catch(FormatException)
                {
                    Console.WriteLine("Error. Please enter a valid year!");
                }
            }

            while (month == 0)
            {
                Console.WriteLine("\nPlease enter the month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());

                    if (month < 1 || month > 12)
                    {
                        Console.WriteLine("Error. You have entered an invalid value!");

                        month = 0;
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Error. Please enter a valid month!");
                }
            }

            myStaff = fr.ReadFile();

            for (int i = 0; i < myStaff.Count; i++)
            {
                try
                {                   
                    Console.WriteLine("Enter hours worked for: {0}", myStaff[i].NameOfStaff);
                    int hoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].HoursWorked = hoursWorked;
                    myStaff[i].CalculatePay();
                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);
            Console.Read();
        }
    }
}
