using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        private readonly List<double> _grades;
        public const string Category = "Science";

        public InMemoryBook(string name): base(name)
        {
            _grades = new List<double>();
        }

        public void AddGrade(char grade)
        {
            switch (grade)
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
             case 'D':
                 AddGrade(60);
                 break;
             case 'E':
                 AddGrade(50);
                 break;
             default:
                 AddGrade(0);
                 break;
            }
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >=  0)
            {
                _grades.Add(grade);
                GradeAdded?.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var grade in _grades)
            {
                result.Add(grade);
            }
            
            return result;
        }
    }
}