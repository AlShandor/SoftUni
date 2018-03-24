public class Employee
{
    private string name;
    private decimal salary;
    private string position;
    private string department;
    private string email;
    private int age;

    public Employee(string name, decimal salary, string position, string department)
    {
        Name = name;
        Salary = salary;
        Position = position;
        Department = department;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public decimal Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public string Position
    {
        get { return position; }
        set { position = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string Email
    {
        get { return email; }
        set { email = value; }
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public Employee()
    {

    }

    public Employee(string[] employeeInfo)
    {
        Name = employeeInfo[0];
        Salary = decimal.Parse(employeeInfo[1]);
        Position = employeeInfo[2];
        Department = employeeInfo[3];
        Email = "n/a";
        Age = -1;

        if (employeeInfo.Length == 6)
        {
            Email = employeeInfo[4];
            Age = int.Parse(employeeInfo[5]);
        }
        if (employeeInfo.Length == 5)
        {
            if (employeeInfo[4].Contains("@"))
            {
                Email = employeeInfo[4];
            }
            else
            {
                Age = int.Parse(employeeInfo[4]);
            }
        }
    }
}
