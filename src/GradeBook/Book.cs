using System;
using System.Collections.Generic;

namespace GradeBook {
    
    public class Book {
       
        private string name;
        private List<double> grades;
        
        public Book(string name) {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade) {
            if (grade >= 0 && grade <=100) {
                grades.Add(grade);
            }
            
        }

        public Statistics GetStatistics() {

            Statistics result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;

            foreach (double grade in grades) {
                result.High = Math.Max(grade, result.High);
                result.Low = Math.Min(grade,result.Low);
                result.Average += grade;
            }

            result.Average /= grades.Count;

            return result;

        }
    }
}