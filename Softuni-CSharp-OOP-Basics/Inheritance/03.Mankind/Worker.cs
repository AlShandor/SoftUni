
using System;
using System.Text;

class Worker:Human
{
    private const int MIN_WEEK_SALARY = 10;
    private const int MIN_WORKING_HOURS = 1;
    private const int MAX_WORKING_HOURS = 12;

    private decimal weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, 
        decimal weekSalary, double hoursPerDay)
    :base(firstName,lastName)
    {
        WeekSalary = weekSalary;
        WorkHoursPerDay = hoursPerDay;
    }
    
    public decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value <= MIN_WEEK_SALARY)
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < MIN_WORKING_HOURS || value > MAX_WORKING_HOURS)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }

    private decimal SalaryPerHour
    {
        get { return (this.WeekSalary / 5) / (decimal)this.WorkHoursPerDay; }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {base.FirstName}")
            .AppendLine($"Last Name: {base.LastName}")
            .AppendLine($"Week Salary: {this.WeekSalary:f2}")
            .AppendLine($"Hours per day: {this.WorkHoursPerDay:f2}")
            .AppendLine($"Salary per hour: {this.SalaryPerHour:f2}");

        return sb.ToString().TrimEnd();
    }
}
