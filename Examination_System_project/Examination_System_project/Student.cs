using System;
using System.Collections.Generic;

namespace Examination_System_project
{
    internal class Student : Person
    {
        //fields

        private string _email;


        public List<Course> EnrolledCourses { get; set; }
        public List<ExamAttempt> Attempts { get; set; }


        //properties
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (!(value.EndsWith("@gmail.Com")) || _email != value || string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("Invalid Email");
                }
                else
                {
                    _email = value;
                }
            }
        }

        //constructor
        public Student(int id, string name, string email) : base(id, name)
        {

            _email = email;
            EnrolledCourses = new List<Course>();
            Attempts = new List<ExamAttempt>();

        }


        //methods
        public void Enroll(Course course)
        {
            if (!EnrolledCourses.Any(c => c.Title == course.Title))
            {
                EnrolledCourses.Add(course);
                Console.WriteLine($"{Name} enrolled in {course.Title}");
            }
            else
            {
                Console.WriteLine($"{Name} is already enrolled in {course.Title}");
            }
        }
        public ExamAttempt TakeExam(Exam exam)
        {
            var attempt = new ExamAttempt { Id = Attempts.Count + 1, Student = this, Exam = exam };
            Attempts.Add(attempt);
            return attempt;
        }
        public void SubmitAnswer(ExamAttempt attempt, Question question, object answer)
        {
            if (attempt == null) return;

            attempt.AddAnswer(question, answer);
            Console.WriteLine($"{Name} submitted answer for question: {question.Text}");
        }

        public void GetReport(ExamAttempt attempt)
        {
            if (attempt == null) return;

            attempt.CalculateAutoScore();
            attempt.CalculateTotal();

            Console.WriteLine("===== Exam Report =====");
            Console.WriteLine($"Exam Title   : {attempt.Exam.Title}");
            Console.WriteLine($"Student Name : {Name}");
            Console.WriteLine($"Course Name  : {attempt.Exam._title}");
            Console.WriteLine($"Score        : {attempt.TotalScore}/{Course.MaximumDegree}");
            Console.WriteLine($"Status       : {(attempt.IsPassed() ? "Pass" : "Fail")}");
            Console.WriteLine("========================");
        }

    }

}
