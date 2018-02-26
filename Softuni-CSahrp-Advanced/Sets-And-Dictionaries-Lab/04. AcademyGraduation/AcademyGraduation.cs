using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.AcademyGraduation
{
    class AcademyGraduation
    {
        static void Main()
        {
            int numberStudents = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<double>> studentGrades = new SortedDictionary<string, List<double>>();

            for (int i = 0; i < numberStudents; i++)
            {
                string studentName = Console.ReadLine();
                List<double> grades = Console.ReadLine().Split(new char[] { }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(double.Parse)
                                                    .ToList();

                if (!studentGrades.ContainsKey(studentName))
                {
                    studentGrades[studentName] = new List<double>();
                }

                foreach (var grade in grades)
                {
                    studentGrades[studentName].Add(grade);
                }
            }

            foreach (var student in studentGrades)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}"); 
            }
        }
    }
}
