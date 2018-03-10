
using System;
using System.Collections.Generic;
using System.Data;

namespace BashSoft.Models
{
    public class Course
    {
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        private string name;
        private Dictionary<string, Student> studentsbyName;

        public Course(string name)
        {
            this.Name = name;
            studentsbyName = new Dictionary<string, Student>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.name = value;
            }
        }

        public IReadOnlyDictionary<string, Student> StudentsbyName => (IReadOnlyDictionary<string, Student>)studentsbyName;

        public void EnrollStudent(Student student)
        {
            if (this.studentsbyName.ContainsKey(student.UserName))
            {
                throw new DuplicateEntryInStructureException(
                    student.UserName, this.name);
            }

            this.studentsbyName.Add(student.UserName, student);
        }
    }
}
