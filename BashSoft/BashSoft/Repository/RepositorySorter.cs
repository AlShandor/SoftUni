﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BashSoft
{
    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> studentsMarks, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                PrintStudents(studentsMarks.OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else if (comparison == "descending")
            {
                PrintStudents(studentsMarks.OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(pair => pair.Key, pair => pair.Value));
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidComparisonQuery);
            }
        }

        private void PrintStudents(Dictionary<string, double> studentsMarks)
        {
            foreach (KeyValuePair<string, double> keyValuePair in studentsMarks)
            {
                OutputWriter.PrintStudent(keyValuePair);
            }
        }
    }
}