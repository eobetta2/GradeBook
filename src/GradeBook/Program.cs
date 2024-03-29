﻿using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Ibook book = new DiskBook("George's Grade Book");
            book.GradeAdded += OnGradeAdded;

            bool done = false;
            done = EnterGrades(book, done);

            Statistics stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N2}");
            Console.WriteLine($"The letter is {stats.letter}");

        }

        private static bool EnterGrades(Ibook book, bool done)
        {
            while (!done)
            {
                System.Console.WriteLine("Please enter a grade or 'q' to quit: ");
                var input = Console.ReadLine();

                if (input.ToLower() == "q")
                {
                    done = true;
                    break;
                }
                else
                {

                    try
                    {
                        double grade = double.Parse(input);
                        book.AddGrade(grade);
                    }

                    catch (ArgumentException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    finally
                    {
                        Console.WriteLine("");
                    }
                }
            }

            return done;
        }

        static void OnGradeAdded(object sender, EventArgs ev) {
            Console.WriteLine("Grade was added");
        }
    }
}