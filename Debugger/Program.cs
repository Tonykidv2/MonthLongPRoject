using EFDatabase.TBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugger
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeManagementEntities db = new EmployeeManagementEntities();

            
            Employee emp = new Employee();
            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                emp.Name = "Name: " + i;
                int booo = rnd.Next(1);
                if (booo == 1)
                    emp.IsMale = true;
                else
                    emp.IsMale = false;
                emp.PhoneNumber = rnd.Next(1231234, 3214321);
                emp.Age = rnd.Next(18, 50);
                emp.DateofBirth = DateTime.Now;
                emp.Email = "Something00" + i + "@infoSys.com";
                emp.State = rnd.Next(1, 50);
                emp.Educations.Add(db.Educations.Single(p => p.EducationID == 4));
            }
            Console.WriteLine(emp.Name);
            Console.ReadLine();
        }
    }
}
