using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5_20
{
    class Program
    {
        static void Main()
        {
            List<Employee> empList = new List<Employee>();
            decimal hoursWorked, wageNum;

            bool stayInLoop = true;
            do
            {
                Console.WriteLine($"\nEnter Employees First Name, (Enter Nothing To Be Done): ");
                string fName = Console.ReadLine();
                if (fName != String.Empty)
                {
                    Console.WriteLine($"Enter Employees Last Name, (Enter Nothing To Be Done): ");
                    string lName = Console.ReadLine();
                    if (lName != String.Empty)
                    {
                        Console.WriteLine($"Enter Employees Hourly Wage, (Enter Nothing To Be Done): ");
                        if (decimal.TryParse(Console.ReadLine(), out wageNum))
                        {
                            Console.WriteLine($"Enter Hours Worked, (Enter Nothing To Be Done): ");
                            if (decimal.TryParse(Console.ReadLine(), out hoursWorked))
                            {
                                empList.Add(new Employee(fName, lName, wageNum, hoursWorked));
                            }

                            else
                            {
                                stayInLoop = false;
                            }
                        }

                        else
                        {
                            stayInLoop = false;
                        }
                    }

                    else
                    {
                        stayInLoop = false;
                    }
                }

                else
                {
                    stayInLoop = false;
                }

            } while(stayInLoop);

            Console.WriteLine("\n\n\t--- Employees Weekly Payments ---");
            foreach(Employee tmpEmp in empList)
            {
                Console.WriteLine($"{tmpEmp.FirstName} {tmpEmp.LastName} Weekly Payment: {tmpEmp.GetWeeksPay():C}");
            }

        }
    }
}
