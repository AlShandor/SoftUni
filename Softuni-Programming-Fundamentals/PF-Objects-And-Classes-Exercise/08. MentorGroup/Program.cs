using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MentorGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Student> StudentCollection = new Dictionary<string, Student>();

            //Create Student object with dates and put it in collection 
            string inputDates = Console.ReadLine();
            while (inputDates != "end of dates")
            {
                string studentName = inputDates.Split(' ').First();
                List<DateTime> datesAttended = GetListOfDates(inputDates);
                Student newStudent = GetNewStudent(studentName, datesAttended);
                UpdateStatsForStudentIfExist(studentName, datesAttended, StudentCollection);
                if (StudentCollection.ContainsKey(studentName))
                {
                    inputDates = Console.ReadLine();
                    continue;
                }

                PutStudentToStudentCollection(newStudent, StudentCollection);

                inputDates = Console.ReadLine();
            }

            //Get comments from users and add them to Students objects
            string inputComments = Console.ReadLine();
            while (inputComments != "end of comments")
            {
                string studentName = inputComments.Split('-').First();
                if (!StudentCollection.ContainsKey(studentName))
                {
                    inputComments = Console.ReadLine();
                    continue;
                }
                string studentComment = inputComments.Split('-').Skip(1).ToArray().First();
                AssignCommentToStudent(studentName, StudentCollection, studentComment);

                inputComments = Console.ReadLine();
            }
            PrintStudentsInfo(StudentCollection);
        }

        private static void PrintStudentsInfo(Dictionary<string, Student> studentCollection)
        {
            foreach (var student in studentCollection.OrderBy(x => x.Key))
            {
                Console.WriteLine(student.Key);
                Console.WriteLine("Comments:");
                foreach (var comment in student.Value.Comments)
                {
                    Console.WriteLine($"- {comment}");
                }
                Console.WriteLine("Dates attended:");
                foreach (var date in student.Value.DatesAttended.OrderBy(x => x).ToList())
                {
                        Console.WriteLine($"-- {date:dd/MM/yyyy}");
                }
            }
        }

        private static void AssignCommentToStudent(string studentName, Dictionary<string, Student> studentCollection, string studentComment)
        {
            if (studentCollection.ContainsKey(studentName))
            {
                studentCollection[studentName].Comments.Add(studentComment);
            }
        }

        private static void UpdateStatsForStudentIfExist(string studentName, List<DateTime> datesAttended, Dictionary<string, Student> StudentCollection)
        {
            if (StudentCollection.ContainsKey(studentName))
            {
                StudentCollection[studentName].DatesAttended.AddRange(datesAttended);
            }
        }

        private static Student GetNewStudent(string studentName, List<DateTime> datesAttended)
        {
            Student newStudent = new Student();
            newStudent.Name = studentName;
            newStudent.DatesAttended = datesAttended;
            return newStudent;
        }

        private static void PutStudentToStudentCollection(Student newStudent, Dictionary<string, Student> studentCollection)
        {
            if (!studentCollection.ContainsKey(newStudent.Name))
            {
                studentCollection.Add(newStudent.Name, newStudent);
            }
        }

        private static List<DateTime> GetListOfDates(string inputDates)
        {
            List<DateTime> datesAttended = new List<DateTime>();
            string[] datesArr = inputDates.Split(new char[] { ' ', ',' }).Skip(1).ToArray();
            foreach (var date in datesArr)
            {
                DateTime temp = DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                datesAttended.Add(temp);
            }
            return datesAttended;
        }

        class Student
        {
            public string Name { get; set; }
            public List<DateTime> DatesAttended = new List<DateTime>();
            public List<string> Comments = new List<string>();
        }
    }
}
