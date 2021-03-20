using System;
using System.Collections.Generic;
using System.Text;

namespace exercise4._11
{
    class Employee
    {
        private decimal salary = 0;
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Employee(string fName, string lName, decimal tmpSalary)
        {
            FirstName = fName;
            LastName = lName;
            Salary = tmpSalary;
        }

        public decimal Salary
        {
            get
            {
                return salary;
            }

            set
            {
                if (value >= 0m)
                {
                    salary = value;
                }

                else
                {
                    Console.WriteLine("\nInvalid Value, Must be Positive\n");
                }
            }
        }
    }
}
