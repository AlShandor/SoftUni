
using System;
using System.Linq;
using System.Text;

class Student:Human
{
    private const int MIN_FAC_NUM_LENGTH = 5;
    private const int MAX_FAC_NUM_LENGTH = 10;

    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        :base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < MIN_FAC_NUM_LENGTH || value.Length > MAX_FAC_NUM_LENGTH || 
                !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"First Name: {base.FirstName}")
            .AppendLine($"Last Name: {base.LastName}")
            .AppendLine($"Faculty number: {this.FacultyNumber}");

        return sb.ToString().TrimEnd();
    }
}
