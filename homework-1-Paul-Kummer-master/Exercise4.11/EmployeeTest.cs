using System;

namespace exercise4._11
{
    class EmployeeTest
    {
        static void Main()
        {
            Employee emp1 = new Employee("Paul", "Kummer", 5000);
            Employee emp2 = new Employee("", "", 0);

            Console.WriteLine("---[Inintial Employee Values]---");
            DisplayEmps();

            emp1.FirstName = "Bob";
            emp1.LastName = "Bobber";
            emp1.Salary = 1m;

            emp2.FirstName = "Steve";
            emp2.LastName = "Martin";
            emp2.Salary = -15000m;

            Console.WriteLine("---[Employees after attempting negative sarlary and name changes]---");
            DisplayEmps();

            emp2.Salary = 15000m;

            Console.WriteLine("---[Employees after making emp2's salary positve]---");
            DisplayEmps();

            emp1.Salary *= 1.1m;
            emp2.Salary *= 1.1m;

            Console.WriteLine("---[Employees after getting 10% raise]---");
            DisplayEmps();



            void DisplayEmps()
            {
                Console.WriteLine("\t---[Employee 1]---");
                Console.WriteLine($"\nFirst Name: {emp1.FirstName}" +
                                  $"\nLast Name: {emp1.LastName}" +
                                  $"\nYearly Salary: {(emp1.Salary * 12m):C}\n");

                Console.WriteLine("\t---[Employee 2]---");
                Console.WriteLine($"\nFirst Name: {emp2.FirstName}" +
                                  $"\nLast Name: {emp2.LastName}" +
                                  $"\nYearly Salary: {(emp2.Salary * 12m):C}\n");
            }

        }
    }
}
