using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AverageGrades
{
    class Program
    {
        class Student
        {
            public string Name { get; set; }
            public double[] Grades { get; set; }
            public double AverageGrade
            {
                get
                {
                    return Grades.Average();
                }
            }
        }

        static void Main(string[] args)
        {
            var listOfStudents = new List<Student>();
            int numOfStudents = int.Parse(Console.ReadLine());
            for (int currentStudent = 0; currentStudent < numOfStudents; currentStudent++)
            {
                string[] studentNameAndGrades = Console.ReadLine().Split(' ');
                string studentName = studentNameAndGrades[0];
                double[] studentGrades = studentNameAndGrades.Skip(1).Select(double.Parse).ToArray();
                Student newStudent = new Student()
                {
                    Name = studentName,
                    Grades = studentGrades
                };
                listOfStudents.Add(newStudent);
            }

            listOfStudents = listOfStudents
                .OrderBy(a => a.Name)
                .ThenByDescending(a => a.AverageGrade)
                .ToList();
            foreach (var s in listOfStudents)
            {
                if (s.AverageGrade >= 5.00)
                {
                    Console.WriteLine($"{s.Name} -> {s.AverageGrade:f2}");
                }
                
            }
        }
    }
}
