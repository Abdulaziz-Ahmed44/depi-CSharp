using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_System_project
{
    internal class Instructor : Person
    {
        // fields
        private string _specialization;

        public List<Course> Courses { get; private set; }

        //properties
        public string Specialization
        {
            get
            {
                return _specialization;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Console.WriteLine("Invalid Specialization");

                }
                else
                {
                    _specialization = value;
                }
            }
        }

        //constuctor
        public Instructor(int id, string name, string specialization) : base(id, name)
        {
            Specialization = specialization;
        }



        //methods
        public bool AssignCourse(Course course)
        {
            if (!Courses.Contains(course))
            {
                Courses.Add(course);
                return true;
            }
            return false;
        }

        public Exam CreateExam(Course course, string title)
        {
            if (!Courses.Contains(course))
            {
                Console.WriteLine($"Instructor {Name} is not assigned to this course.");
            }

            return new Exam
            {
                id = new Random().Next(1000, 9999),
                Title = title,
                Course = course,
                Status = Exam.ExamStatus.Draft
            };
        }

        public bool AddQuestion(Exam exam, Question q)
        {
            if (exam.Status == Exam.ExamStatus.Draft)
            {
                exam.questions.Add(q);
                return true;
            }
            return false;
        }

        public bool GradeEssay(ExamAttempt attempt, EssayQuestion q, int mark)
        {
            var ans = attempt.Answers.FirstOrDefault(a => a.Question.Id == q.Id);
            if (ans == null) return false;

            ans.AssignManualMark(mark);
            attempt.ManualScore += mark;
            return true;
        }

        public Exam DuplicateExam(Exam exam, Course targetCourse)
        {
            var copy = new Exam
            {
                id = new Random().Next(1000, 9999),
                Title = exam.Title + " (Copy)",
                Course = targetCourse,
                Status = Exam.ExamStatus.Draft,

            };
            copy.questions.AddRange(exam.questions);
            return copy;
        }
    }

}
