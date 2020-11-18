namespace GradeBook
{
    public class Statistics
    {
        public double Average 
        {
            get {
                if(count > 0)
                {
                    return sum / count;
                }
                else
                {
                    return 0.0;
                }
                
            }
        }
        public double High;
        public double Low;

        public char Letter {
            get {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                        
                    case var d when d >= 80.0:
                        return 'B';
                        
                    case var d when d >= 70.0:
                        return 'C';
                        
                    case var d when d >= 60.0:
                        return 'D';
                        
                    default:
                        return 'F';  
                }
            }
        }

        private int count;

        private double sum;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            count = 0;

        }

        public void AddGrade(double grade) {
            count += 1;
            sum += grade;
            High = System.Math.Max(grade, High);
            Low = System.Math.Min(grade, Low);
        }
    }
}