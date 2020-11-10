using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Cliffs Gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.5);

            var stats = book.GetStatistics();
            System.Console.WriteLine($"Average grade is {stats.Average:N1}.");
            System.Console.WriteLine($"High grade is {stats.High:N1}.");
            System.Console.WriteLine($"Low grade is {stats.Low:N1}.");
        }
    }
}
