﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Cliffs Gradebook");
            book.GradeAdded += OneGradeAdded;

            EnterGrades(book);
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter grade or 'q' to quit: ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    System.Console.WriteLine($"{ex.Message}");
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine($"{ex.Message}");
                }
                finally
                {
                    System.Console.WriteLine("**");
                }
            }



            var stats = book.GetStatistics();
            System.Console.WriteLine($"Average grade is {stats.Average:N1}.");
            System.Console.WriteLine($"High grade is {stats.High:N1}.");
            System.Console.WriteLine($"Low grade is {stats.Low:N1}.");
            System.Console.WriteLine($"The letter grade is {stats.Letter}.");
        }

        static void OneGradeAdded(object sender, EventArgs args)
        {
            System.Console.WriteLine("A grade was added.");
        }
    }
}
