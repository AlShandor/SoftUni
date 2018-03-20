using System.Collections.Generic;

public class Department
{
    private string name;
    private decimal averageSalaray;

    
    public string Name { get; set; }
    public decimal AverageSalary { get; set; }
    public List<Employee> Employees = new List<Employee>();
}
