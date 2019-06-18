using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book  = new Book("George's Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(91.1);
            book.AddGrade(76.67);

            Statistics stats = book.GetStatistics();

            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");

        }
    }
}