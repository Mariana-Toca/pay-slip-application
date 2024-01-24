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
                    sw.WriteLine($"PAYSLIP FOR {0} {1}", (MonthsOfYear)month, year);
                }
            }
        }
    }
}
