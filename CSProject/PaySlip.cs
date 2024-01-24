using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    public class PaySlip
    {
        private int month;
        private int year;

        enum MonthsOfYear
        {
            January = 1, February = 2, March, April, May, June, July, August, September, October, November, December
        }

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;
            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff f in myStaff)
            {
                path = f.NameOfStaff + ".txt";
                using(StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("PAYSLIP FOR {0}, {1}", (MonthsOfYear)month, year);
                    sw.WriteLine("=================================================");
                    sw.WriteLine("Name of Staff: {0}", f.NameOfStaff);
                    sw.WriteLine("Hours Worked: {0}", f.HoursWorked);
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {0:C}", f.BasicPay);

                    if (f.GetType() == typeof(Manager))
                    {
                        sw.WriteLine("Allowance: {0}", ((Manager)f).Allowance);
                    }

                    if (f.GetType() == typeof(Admin))
                    {
                        sw.WriteLine("Allowance: {0}", ((Admin)f).Overtime);
                    }

                    sw.WriteLine("");
                    sw.WriteLine("==================================================");
                    sw.WriteLine("Total Pay: {0:C}", f.TotalPay);
                    sw.WriteLine("==================================================");

                    sw.Close();
                }                
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result = from f in myStaff
                         where (f.HoursWorked < 10)
                         orderby f.NameOfStaff ascending
                         select new { f.NameOfStaff, f.HoursWorked };

            /*var result1 = myStaff.Select(f => new { f.NameOfStaff, f.HoursWorked })
                .Where(f => f.HoursWorked < 10)
                .OrderBy(f => f.NameOfStaff);
            */

            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("Staff with less than 10 working hours");
                sw.WriteLine("");

                foreach(var f in result)
                {
                    sw.WriteLine("Name of Staff: {0}, Hours Worked: {1}", f.NameOfStaff, f.HoursWorked);                    
                }
                sw.Close();
            }
        }
        public override string ToString()
        {
            return "Month = " + month + ", Year = " + year;           
        }
    }
}
