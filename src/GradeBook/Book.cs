using System.Collections.Generic;
using System;
using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject 
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name {
            get;
            set;
        }
    }

    public abstract class Book: NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }

    public interface IBook 
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public class DiskBook : Book, IBook
    {
        public DiskBook(string name) : base(name)
        {
            
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            
            using(var grades = File.AppendText($"{Name}.txt"))
            {
                grades.WriteLine(grade);
            } 

            if(GradeAdded != null)
            {
                GradeAdded(this, new EventArgs());
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            string grade;

            using(var grades = File.OpenText($"{Name}.txt"))
            {
                while((grade = grades.ReadLine()) != null)
                {
                    result.AddGrade(double.Parse(grade));
                }

            }

            return result;
        }

    }

    public class InMemoryBook : Book
    {
        public InMemoryBook(string name) : base(name) {

            grades = new List<double>();
            Name = name;
        }

        public override Statistics GetStatistics() {
            var result = new Statistics();

            foreach(var grade in grades) {
                result.AddGrade(grade);
            }

            return(result);
        }
        
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public void AddLetterGrade(char letter)
        {
            switch (letter) 
            {
                case 'A':
                    AddGrade(90);
                    break;
                
                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        private List<double> grades;
    }
}