using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Patrick's grade book");
            book.GradeAdded += OnGradeAdded; 
            
            EnterGrades(book);

            var stats = book.GetStatistics();
            Console.WriteLine($"For the book named {book.Name} in {InMemoryBook.Category}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            var input = "";

            while (input != "q")
            {
                Console.Write("Please enter a grade or q to quit: ");
                input = Console.ReadLine();
                if (double.TryParse(input, out var result))
                {
                    try
                    {
                        book.AddGrade(result);
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        Console.WriteLine("***");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            
        }
    }
}
