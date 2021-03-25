using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average => _sum / _count;
        public double High;
        public double Low;

        public char Letter
        {
            get
            {
                return Average switch
                {
                    >= 90.0 => 'A',
                    >= 80.0 => 'B',
                    >= 70.0 => 'C',
                    >= 60.0 => 'D',
                    >= 50.0 => 'E',
                    _ => 'F'
                };

            }
        }

        private double _sum;
        private int _count;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            _sum = 0.0;
            _count = 0;
        }

        public void Add(double number)
        {
            _sum += number;
            _count++;
            High = Math.Max(High, number);
            Low = Math.Min(Low, number);
        }
        
        
    }
}