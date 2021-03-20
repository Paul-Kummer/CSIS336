public class Employee
{
    private decimal wage = 0;
    public decimal HoursWorked { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Employee(string fName, string lName, decimal tmpWage, decimal tmpHours=0)
    {
        FirstName = fName;
        LastName = lName;
        Wage = tmpWage;
        HoursWorked = tmpHours;
    }

    public decimal Wage
    {
        get
        {
            return wage;
        }

        set
        {
            if (value >= 0)
            {
                wage = value;
            }
        }
    }

    public decimal GetWeeksPay()
    {
        decimal earnedIncome 
            = HoursWorked <= 40 
            ? HoursWorked * wage 
            : (40 * wage) + ((HoursWorked - 40) * (wage * (decimal)1.5));
        return earnedIncome;
    }
}
