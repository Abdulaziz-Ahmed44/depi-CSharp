using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_System_project
{
    internal class Exam
    {
        //fields
        private int _id;
        public string _title;
        public List<Question> questions { get; private set; }


        // properties 
        public int id
        {
            get
            {
                return _id;
            }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Invalid Id");
                }
                else
                {
                    _id = value;
                }
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 3 || value.Length > 100))
                {
                    Console.WriteLine("Invalid Title.");
                }
                else
                {
                    _title = value;
                }
            }
        }

        public Course Course { get; set; }
        public ExamStatus Status { get; set; } = ExamStatus.Draft;


        public enum ExamStatus
        {
            Draft,
            Scheduled,
            Ongoing,
            Completed
        }




        public void Schedule()
        {
            if (Status != ExamStatus.Draft)
            {
                Console.WriteLine("Only Draft exams can be scheduled.");
            }
            else
            {
                Status = ExamStatus.Scheduled;
            }
        }


        public void StartExam()
        {
            if (Status != ExamStatus.Scheduled)
            {
                Console.WriteLine("Exam must be Scheduled before starting.");
            }
            else
            {
                Status = ExamStatus.Ongoing;
            }


        }


        public void CloseExam()
        {
            if (Status != ExamStatus.Ongoing)
            {
                Console.WriteLine("Exam must be Running to close.");
            }
            else
            {
                Status = ExamStatus.Completed;
            }
        }
        public decimal GetTotalMarks()
        {
            return questions.Sum(q => q._mark);
        }


    }
}
