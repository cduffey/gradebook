namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;

        public char Letter;

        public Statistics(double average, double high, double low, char letter)
        {
            Average = average;
            High = high;
            Low = low;
            Letter = letter;
        }
    }
}