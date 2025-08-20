using System;

namespace Examination_System_project
{
    internal static class ReportService
    {

        //methods
        public static void GenerateReport(ExamAttempt attempt)
        {
            Console.WriteLine("===== Exam Report =====");
            Console.WriteLine($"Exam Title   : {attempt.Exam.Title}");
            Console.WriteLine($"Student Name : {attempt.Student.Name}");
            Console.WriteLine($"Course Name  : {attempt.Exam.Course.Title}");
            Console.WriteLine($"Score        : {attempt.TotalScore} / {attempt.Exam.questions.Sum(q => q._mark)}");
            Console.WriteLine($"Status       : {(attempt.IsPassed() ? "PASS " : "FAIL ")}");
            Console.WriteLine("========================\n");
        }

        public static void CompareStudents(Exam exam, Student s1, Student s2)
        {
            var attempt1 = s1.Attempts.FirstOrDefault(a => a.Exam == exam);
            var attempt2 = s2.Attempts.FirstOrDefault(a => a.Exam == exam);

            if (attempt1 == null || attempt2 == null)
            {
                Console.WriteLine("❌ One or both students have not taken this exam.");
                return;
            }

            Console.WriteLine($"Comparing {s1.Name} vs {s2.Name} in exam: {exam.Title}");

            if (attempt1.TotalScore > attempt2.TotalScore)
                Console.WriteLine($"{s1.Name} scored higher ({attempt1.TotalScore} vs {attempt2.TotalScore})");
            else if (attempt1.TotalScore < attempt2.TotalScore)
                Console.WriteLine($"{s2.Name} scored higher ({attempt2.TotalScore} vs {attempt1.TotalScore})");
            else
                Console.WriteLine($"Both students scored the same ({attempt1.TotalScore})");
        }
    }



}
