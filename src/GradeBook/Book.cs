using System;
using System.Collections.Generic;
using System.IO;

namespace GradeBook {

    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject {
        public NamedObject(string name) {
            Name = name;
        }

        public string Name {
            get; 
            set;
        }

    }

    public interface Ibook {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name {get;}
        event GradeAddedDelegate GradeAdded;

    }

    public abstract class Book : NamedObject, Ibook{
        public Book(string name) : base(name){}

        public abstract event GradeAddedDelegate GradeAdded;
        public abstract void AddGrade(double grade);
        public abstract Statistics GetStatistics();

    }

    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            if (grade >= 0 && grade <=100) {


                using(var writer = File.AppendText($"{Name}.txt")) {
                    writer.WriteLine(grade);
                }
                
                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                } 

            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
            
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (var reader = File.OpenText($"{Name}.txt")) {
                var line = reader.ReadLine();

                while (line != null) {
                    var number = double.Parse(line);
                    result.Add(number);
                    line = reader.ReadLine();
                }
                    
            }

            return result;
        }
    }

    public class InMemoryBook : Book {
       
        private List<double> grades;

        public InMemoryBook(string name) : base(name) {
            grades = new List<double>();
            this.Name = name;

        }

        public override void AddGrade(double grade) {
            if (grade >= 0 && grade <=100) {
                grades.Add(grade);

                if (GradeAdded != null) {
                    GradeAdded(this, new EventArgs());
                } 

            } else {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }

        }

        public override event GradeAddedDelegate GradeAdded;

        public override Statistics GetStatistics() {

            Statistics result = new Statistics();
            
            for (int i = 0; i < grades.Count; i++) {

                result.Add(grades[i]);
            }

            return result;

        }

        public static implicit operator InMemoryBook(DiskBook v)
        {
            throw new NotImplementedException();
        }
    }
}