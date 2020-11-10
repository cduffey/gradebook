using System.Collections.Generic;
using System;

namespace GradeBook
{

    public class Book
    {
        public Book(string name) {
            grades = new List<double>();
            this.name = name;
        }

        public Statistics GetStatistics() {
            var result = new Statistics();

            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach(var grade in grades) {
                result.Average += grade;
                result.High = Math.Max(result.High, grade);
                result.Low = Math.Min(result.Low, grade);
            }

            result.Average /= grades.Count;
            return(result);
        }
        
        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        private List<double> grades;
        private string name;

    }
}