using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSProject
{
    public class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {                       
                        string text = sr.ReadLine();
                        string[] substrings = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                        if (substrings[1] == "Manager")
                        {
                            Manager item = new Manager(substrings[0]);
                            myStaff.Add(item);
                        }

                        if (substrings[1] == "Admin")
                        {
                            Admin item = new Admin(substrings[0]);
                            myStaff.Add(item);
                        }
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }

            return myStaff;
        }

    }
}
