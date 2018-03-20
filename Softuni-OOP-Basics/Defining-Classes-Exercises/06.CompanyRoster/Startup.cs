using System;
using System.Collections.Generic;
using System.Linq;

class Startup
{
    static void Main()
    {
        int numEmployees = int.Parse(Console.ReadLine());
        Dictionary<string, Department> departments = new Dictionary<string, Department>();


        for (int i = 0; i < numEmployees; i++)
        {
            var employeeInfo = Console.ReadLine().Split();
            Employee newEmployee = new Employee(employeeInfo);

            string currentDepartment = employeeInfo[3];
            if (!departments.ContainsKey(currentDepartment))
            {
                departments[currentDepartment] = new Department();
                departments[currentDepartment].Name = currentDepartment;
            }

            departments[currentDepartment].Employees.Add(newEmployee);
        }


        foreach (var department in departments)
        {
            foreach (var employee in department.Value.Employees)
            {
                department.Value.AverageSalary += employee.Salary;
            }

            department.Value.AverageSalary /= department.Value.Employees.Count;
        }

        var departmentWithHighestAverageSalary = departments.OrderByDescending(x => x.Value.AverageSalary).First();
        PrintDepartmentInfo(departmentWithHighestAverageSalary);

    }

    private static void PrintDepartmentInfo(KeyValuePair<string, Department> departmentWithHighestAverageSalary)
    {
        Console.WriteLine($"Highest Average Salary: {departmentWithHighestAverageSalary.Key}");
        foreach (var employee in departmentWithHighestAverageSalary.Value.Employees.OrderByDescending(x => x.Salary))
        {
            Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
        }
    }
}
