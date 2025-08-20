using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_System_project
{
    internal class Course
    {
        //fields
        public string _title;
        private string _description;
        private static int _maximumDegree;
        public List<Instructor> instructors { get; private set; }
        public List<Student> students { get; private set; }
        public List<Exam> exams { get; private set; }


        //properties

        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 3 || value.Length > 100))
                {
                    Console.WriteLine("Invalid Title Course.");
                }
                else
                {
                    _title = value;
                }
            }

        }
        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                if (!string.IsNullOrEmpty(value) || (value.Length < 10 || value.Length > 1000))
                {
                    Console.WriteLine("Invalid description ");
                }
                else
                {
                    _description = value;
                }

            }
        }


        public static int MaximumDegree
        {
            get
            {
                return _maximumDegree;
            }
            private set
            {
                if ((value <= 0))
                {
                    Console.WriteLine("Invalid Maximum Degree");

                }
                else
                {
                    _maximumDegree = value;
                }
            }
        }


        //constructor

        public Course(string title, string description, int maximumDegree)
        {
            Title = title;
            Description = description;
            MaximumDegree = maximumDegree;
            exams = new List<Exam>();
            students = new List<Student>();
            instructors = new List<Instructor>();

        }



        // Methods
        public void AddExam(Exam exam)
        {
            if (exam.GetTotalMarks() <= _maximumDegree)
            {
                exams.Add(exam);
                Console.WriteLine($"Exam '{exam.Title}' added to course '{Title}'.");
            }
            else
            {
                Console.WriteLine(" Exam marks exceed MaxDegree");
            }
        }

        public void RemoveExam(int examId)
        {
            var exam = exams.FirstOrDefault(e => e.id == examId);
            if (exam != null)
            {
                exams.Remove(exam);
                Console.WriteLine($"Exam '{exam.Title}' removed from course '{Title}'.");
            }
            else
            {
                Console.WriteLine(" Exam not found.");
            }
        }

        public List<Exam> GetExams()
        {
            return exams;
        }
    }
}