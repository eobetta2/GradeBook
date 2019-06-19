using System;
using System.Collections.Generic;

namespace GradeBook {
    
    public class Book {
       
        public string name;
        private List<double> grades;

        public Book(string name) {
            grades = new List<double>();
            this.name = name;
        }

        public void AddGrade(double grade) {
            if (grade >= 0 && grade <=100) {
                grades.Add(grade);
            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public Statistics GetStatistics() {

            Statistics result = new Statistics();
            result.Average = 0.0;
            result.Low = double.MaxValue;
            result.High = double.MinValue;
            
            for (int i = 0; i < grades.Count; i++) {

                if (grades[i] == 40.0) {
                    continue;
                }

                result.High = Math.Max(grades[i], result.High);
                result.Low = Math.Min(grades[i],result.Low);
                result.Average += grades[i];
            }

            result.Average /= grades.Count;

            switch (result.Average) {
                case var d when d >= 90.0:
                    result.letter = 'A';
                    break;

                case var d when d >= 80.0:
                    result.letter = 'B';
                    break;

                case var d when d >= 70.0:
                    result.letter = 'C';
                    break;

                 case var d when d >= 60.0:
                    result.letter = 'D';
                    break;

                 default:
                    result.letter = 'F';
                    break;              
            }
            return result;

        }
    }
}