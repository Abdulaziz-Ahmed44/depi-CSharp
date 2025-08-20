using System;
using System.Collections.Generic;
using System.Linq;

namespace Examination_System_project
{
    internal class ExamAttempt
    {

        //properties
        public int Id { get; set; }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public int AutoScore { get; set; }
        public int ManualScore { get; set; }
        public int TotalScore { get; set; }

        //methods
        public void AddAnswer(Question q, object response)
        {
            Answers.Add(new Answer
            {
                Question = q,
                Response = response
            });
        }

        public void CalculateAutoScore()
        {
            AutoScore = 0;

            foreach (var ans in Answers)
            {
                var result = ans.Question.CheckAnswer(ans.Response);

                if (result == true)
                {
                    AutoScore += (int)ans.Question._mark;
                }
            }
        }


        public void CalculateTotal()
        {
            TotalScore = AutoScore + ManualScore;
        }

        public bool IsPassed()
        {
            int maxDegree = Course.MaximumDegree;
            return TotalScore >= (maxDegree / 2);
        }
    }
}
