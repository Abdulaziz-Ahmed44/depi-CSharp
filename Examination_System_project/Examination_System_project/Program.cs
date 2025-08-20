using System;
using Examination_System_project;


namespace Examination_System_project
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                List<Course> courses = new List<Course>();
                List<Student> students = new List<Student>();
                List<Instructor> instructors = new List<Instructor>();

                bool running = true;

                while (running)
                {
                    Console.WriteLine("\n===== Main Menu =====");
                    Console.WriteLine("1. Add Course");
                    Console.WriteLine("2. Add Instructor");
                    Console.WriteLine("3. Add Student");
                    Console.WriteLine("4. Enroll Student in Course");
                    Console.WriteLine("5. Assign Instructor to Course");
                    Console.WriteLine("6. Create Exam");
                    Console.WriteLine("7. Add Exam to Course");
                    Console.WriteLine("8. Add Question to Exam");
                    Console.WriteLine("9. Student Take Exam");
                    Console.WriteLine("10. Show Exam Report");
                    Console.WriteLine("11. Compare Two Students");
                    Console.WriteLine("12. Edit Question in Exam");
                    Console.WriteLine("13. Remove Question From Exam");
                    Console.WriteLine("14. Exit");
                    Console.Write("Select option: ");

                    string input = Console.ReadLine();
                    switch (input)
                    {
                        case "1":
                            Console.Write("Course Title: ");
                            string cTitle = Console.ReadLine();
                            Console.Write("Course Description: ");
                            string cDesc = Console.ReadLine();
                            Console.Write("Course Maximum Degree: ");
                            int cMax = int.Parse(Console.ReadLine());

                            courses.Add(new Course(cTitle, cDesc, cMax));
                            Console.WriteLine("Course added!");
                            break;

                        case "2":
                            Console.Write("Instructor ID: ");
                            int iId = int.Parse(Console.ReadLine());
                            Console.Write("Instructor Name: ");
                            string iName = Console.ReadLine();
                            Console.Write("Specialization: ");
                            string spec = Console.ReadLine();

                            instructors.Add(new Instructor(iId, iName, spec));
                            Console.WriteLine("Instructor added!");
                            break;

                        case "3":
                            Console.Write("Student ID: ");
                            int sId = int.Parse(Console.ReadLine());
                            Console.Write("Student Name: ");
                            string sName = Console.ReadLine();
                            Console.Write("Student Email: ");
                            string email = Console.ReadLine();

                            students.Add(new Student(sId, sName, email));
                            Console.WriteLine("Student added!");
                            break;

                    case "4": 
                        if (students.Count == 0 || courses.Count == 0)
                        {
                            Console.WriteLine("No students or courses available.");
                            break;
                        }

                        Console.WriteLine("Select Student by index:");
                        for (int idx = 0; idx < students.Count; idx++)
                            Console.WriteLine($"{idx}. {students[idx].Name}");
                        int studentIndex = int.Parse(Console.ReadLine());
                        Student selectedStudent = students[studentIndex];

                        Console.WriteLine("Select Course by index:");
                        for (int idx = 0; idx < courses.Count; idx++)
                            Console.WriteLine($"{idx}. {courses[idx].Title}");
                        int courseIndexEnroll = int.Parse(Console.ReadLine());
                        Course selectedCourseEnroll = courses[courseIndexEnroll];

                        selectedStudent.Enroll(selectedCourseEnroll);
                        break;


                    case "5":
                            if (instructors.Count == 0 || courses.Count == 0)
                            {
                                Console.WriteLine("No instructors or courses available.");
                                break;
                            }

                            Console.WriteLine("Select Instructor by index:");
                            for (int idx = 0; idx < instructors.Count; idx++)
                                Console.WriteLine($"{idx}. {instructors[idx].Name}");
                            int instIdx = int.Parse(Console.ReadLine());

                            Console.WriteLine("Select Course by index:");
                            for (int idx = 0; idx < courses.Count; idx++)
                                Console.WriteLine($"{idx}. {courses[idx].Title}");
                            int courseIdx = int.Parse(Console.ReadLine());

                            bool assigned = instructors[instIdx].AssignCourse(courses[courseIdx]);
                            Console.WriteLine(assigned ? "Instructor assigned to course!" : "Instructor already assigned.");
                            break;

                    case "6": 
                        if (courses.Count == 0 || instructors.Count == 0)
                        {
                            Console.WriteLine("No courses or instructors available.");
                            break;
                        }

                        
                        Console.WriteLine("Select Course by index:");
                        for (int i = 0; i < courses.Count; i++)
                            Console.WriteLine($"{i}. {courses[i].Title}");
                        int courseIndexExam = int.Parse(Console.ReadLine());
                        Course selectedCourseExam = courses[courseIndexExam];

                        Console.WriteLine("Select Instructor by index:");
                        for (int i = 0; i < instructors.Count; i++)
                            Console.WriteLine($"{i}. {instructors[i].Name}");
                        int instructorIndexExam = int.Parse(Console.ReadLine());
                        Instructor selectedInstructorExam = instructors[instructorIndexExam];

                        if (!selectedInstructorExam.Courses.Contains(selectedCourseExam))
                        {
                            Console.WriteLine($"{selectedInstructorExam.Name} is not assigned to this course.");
                            break;
                        }

                        Console.Write("Enter Exam Title: ");
                        string examTitle = Console.ReadLine();

                        Exam newExam = selectedInstructorExam.CreateExam(selectedCourseExam, examTitle);
                        selectedCourseExam.AddExam(newExam);

                        Console.WriteLine($"Exam '{examTitle}' created successfully for course '{selectedCourseExam.Title}' by {selectedInstructorExam.Name}.");
                        break;


                    case "7":
                            if (courses.Count == 0)
                            {
                                Console.WriteLine("No courses available.");
                                break;
                            }

                            Console.WriteLine("Select Course by index:");
                            for (int idx = 0; idx < courses.Count; idx++)
                                Console.WriteLine($"{idx}. {courses[idx].Title}");
                            int courseIndex = int.Parse(Console.ReadLine());

                            Console.Write("Exam Title: ");
                            string eTitle = Console.ReadLine();

                            var exam = new Exam
                            {
                                id = new Random().Next(1000, 9999),
                                Title = eTitle,
                                Course = courses[courseIndex],
                                Status = Exam.ExamStatus.Draft
                            };

                            courses[courseIndex].AddExam(exam);
                            break;

                        case "8":
                            if (courses.Count == 0)
                            {
                                Console.WriteLine("No courses available.");
                                break;
                            }

                            Console.WriteLine("Select Course by index:");
                            for (int idx = 0; idx < courses.Count; idx++)
                                Console.WriteLine($"{idx}. {courses[idx].Title}");
                            int cIdx = int.Parse(Console.ReadLine());
                            var courseSel = courses[cIdx];

                            if (courseSel.exams.Count == 0)
                            {
                                Console.WriteLine("No exams in this course.");
                                break;
                            }

                            Console.WriteLine("Select Exam by index:");
                            for (int idx = 0; idx < courseSel.exams.Count; idx++)
                                Console.WriteLine($"{idx}. {courseSel.exams[idx].Title}");
                            int eIdx = int.Parse(Console.ReadLine());
                            var examSel = courseSel.exams[eIdx];

                            Console.Write("Question Text: ");
                            string qText = Console.ReadLine();
                            Console.Write("Question Mark: ");
                            decimal qMark = decimal.Parse(Console.ReadLine());

                            Question question = new EssayQuestion(new Random().Next(1000, 9999), qText, qMark);

                            Instructor inst = courseSel.instructors.Count > 0 ? courseSel.instructors[0] : null;
                            if (inst != null)
                            {
                                bool added = inst.AddQuestion(examSel, question);
                                Console.WriteLine(added ? "Question added successfully!" : "Failed to add question. Exam must be Draft.");
                            }
                            else
                            {
                                Console.WriteLine("No instructor assigned to course.");
                            }
                            break;


                     case "9": 
                        {
                            if (students.Count == 0 || courses.Count == 0)
                            {
                                Console.WriteLine("No students or courses available.");
                                break;
                            }

                            Console.WriteLine("Select Student by index:");
                            for (int i = 0; i < students.Count; i++)
                                Console.WriteLine($"{i}. {students[i].Name}");
                            int sIndex = int.Parse(Console.ReadLine());
                            Student studentForExamAttempt = students[sIndex];

                            Console.WriteLine("Select Course by index:");
                            for (int i = 0; i < courses.Count; i++)
                                Console.WriteLine($"{i}. {courses[i].Title}");
                            int cIndex = int.Parse(Console.ReadLine());
                            Course courseForExamAttempt = courses[cIndex];

                            if (!studentForExamAttempt.EnrolledCourses.Contains(courseForExamAttempt))
                            {
                                Console.WriteLine($"{studentForExamAttempt.Name} is not enrolled in this course.");
                                break;
                            }

                            var availableExams = courseForExamAttempt.GetExams()
                                                    .Where(e => e.Status == Exam.ExamStatus.Scheduled)
                                                    .ToList();

                            if (availableExams.Count == 0)
                            {
                                Console.WriteLine("No scheduled exams available for this course.");
                                break;
                            }

                            Console.WriteLine("Select Exam by index:");
                            for (int i = 0; i < availableExams.Count; i++)
                                Console.WriteLine($"{i}. {availableExams[i].Title}");
                            int eIndex = int.Parse(Console.ReadLine());
                            Exam examForAttempt = availableExams[eIndex];

                            ExamAttempt attempt = studentForExamAttempt.TakeExam(examForAttempt);
                            Console.WriteLine($"{studentForExamAttempt.Name} started the exam '{examForAttempt.Title}' for course '{courseForExamAttempt.Title}'.");
                            break;
                        }

                    case "10": 
                        {
                            if (students.Count == 0)
                            {
                                Console.WriteLine("No students available.");
                                break;
                            }

                            Console.WriteLine("Select Student by index:");
                            for (int i = 0; i < students.Count; i++)
                                Console.WriteLine($"{i}. {students[i].Name}");
                            int sIndexReport = int.Parse(Console.ReadLine());
                            Student reportStudent = students[sIndexReport]; 

                            if (reportStudent.Attempts.Count == 0)
                            {
                                Console.WriteLine($"{reportStudent.Name} has not taken any exams yet.");
                                break;
                            }

                            Console.WriteLine("Select Exam Attempt by index:");
                            for (int i = 0; i < reportStudent.Attempts.Count; i++)
                                Console.WriteLine($"{i}. {reportStudent.Attempts[i].Exam.Title} (Course: {reportStudent.Attempts[i].Exam.Course.Title})");
                            int attemptIndex = int.Parse(Console.ReadLine());
                            ExamAttempt reportAttempt = reportStudent.Attempts[attemptIndex]; 

                            reportAttempt.CalculateAutoScore();
                            reportAttempt.CalculateTotal();

                            Console.WriteLine("===== Exam Report =====");
                            Console.WriteLine($"Student Name : {reportStudent.Name}");
                            Console.WriteLine($"Course Name  : {reportAttempt.Exam.Course.Title}");
                            Console.WriteLine($"Exam Title   : {reportAttempt.Exam.Title}");
                            Console.WriteLine($"Score        : {reportAttempt.TotalScore} / {reportAttempt.Exam.questions.Sum(q => q._mark)}");
                            Console.WriteLine($"Status       : {(reportAttempt.IsPassed() ? "Pass" : "Fail")}");
                            Console.WriteLine("========================\n");
                            break;
                        }

                    case "11": 
                        {
                            if (students.Count < 2)
                            {
                                Console.WriteLine("Not enough students to compare.");
                                break;
                            }

                            Console.WriteLine("Select first student by index:");
                            for (int i = 0; i < students.Count; i++)
                                Console.WriteLine($"{i}. {students[i].Name}");
                            int firstIndex = int.Parse(Console.ReadLine());
                            Student firstStudent = students[firstIndex]; 

                            Console.WriteLine("Select second student by index:");
                            for (int i = 0; i < students.Count; i++)
                                if (i != firstIndex) 
                                    Console.WriteLine($"{i}. {students[i].Name}");
                            int secondIndex = int.Parse(Console.ReadLine());
                            Student secondStudent = students[secondIndex]; 

                            var commonExams = firstStudent.Attempts
                                                 .Select(a => a.Exam)
                                                 .Intersect(secondStudent.Attempts.Select(a => a.Exam))
                                                 .ToList();

                            if (commonExams.Count == 0)
                            {
                                Console.WriteLine("No common exams found between these two students.");
                                break;
                            }

                            Console.WriteLine("Select Exam to compare:");
                            for (int i = 0; i < commonExams.Count; i++)
                                Console.WriteLine($"{i}. {commonExams[i].Title} (Course: {commonExams[i].Course.Title})");
                            int examIndex = int.Parse(Console.ReadLine());
                            Exam selectedExam = commonExams[examIndex];

                            var attempt1 = firstStudent.Attempts.First(a => a.Exam == selectedExam);
                            var attempt2 = secondStudent.Attempts.First(a => a.Exam == selectedExam);

                            Console.WriteLine($"Comparing {firstStudent.Name} vs {secondStudent.Name} in exam: {selectedExam.Title}");
                            if (attempt1.TotalScore > attempt2.TotalScore)
                                Console.WriteLine($"{firstStudent.Name} scored higher ({attempt1.TotalScore} vs {attempt2.TotalScore})");
                            else if (attempt1.TotalScore < attempt2.TotalScore)
                                Console.WriteLine($"{secondStudent.Name} scored higher ({attempt2.TotalScore} vs {attempt1.TotalScore})");
                            else
                                Console.WriteLine($"Both students scored the same ({attempt1.TotalScore})");

                            break;
                        }


                    case "12": 
                        {
                            if (instructors.Count == 0)
                            {
                                Console.WriteLine("No instructors available.");
                                break;
                            }

                            Console.WriteLine("Select Instructor by index:");
                            for (int i = 0; i < instructors.Count; i++)
                                Console.WriteLine($"{i}. {instructors[i].Name}");
                            int instrSelIndex = int.Parse(Console.ReadLine()); 
                            Instructor selInstructor = instructors[instrSelIndex]; 

                            if (selInstructor.Courses.Count == 0)
                            {
                                Console.WriteLine("This instructor has no courses assigned.");
                                break;
                            }

                            Console.WriteLine("Select Course by index:");
                            for (int i = 0; i < selInstructor.Courses.Count; i++)
                                Console.WriteLine($"{i}. {selInstructor.Courses[i].Title}");
                            int cSelIndex = int.Parse(Console.ReadLine());
                            Course selCourse = selInstructor.Courses[cSelIndex]; 

                            if (selCourse.exams.Count == 0)
                            {
                                Console.WriteLine("No exams in this course.");
                                break;
                            }

                            Console.WriteLine("Select Exam by index:");
                            for (int i = 0; i < selCourse.exams.Count; i++)
                                Console.WriteLine($"{i}. {selCourse.exams[i].Title}");
                            int examSelIndex = int.Parse(Console.ReadLine()); 
                            Exam selExam = selCourse.exams[examSelIndex]; 
                            if (selExam.questions.Count == 0)
                            {
                                Console.WriteLine("No questions in this exam.");
                                break;
                            }

                            Console.WriteLine("Select Question to edit by index:");
                            for (int i = 0; i < selExam.questions.Count; i++)
                                Console.WriteLine($"{i}. {selExam.questions[i].Text}");
                            int qSelIndex = int.Parse(Console.ReadLine()); 
                            Question selQuestion = selExam.questions[qSelIndex]; 

                            Console.Write("Enter new text for the question: ");
                            string newQText = Console.ReadLine(); 

                            Console.Write("Enter new mark for the question: ");
                            decimal newQMark = decimal.Parse(Console.ReadLine()); 

                            selQuestion.Text = newQText;
                            selQuestion._mark = newQMark;

                            Console.WriteLine("Question updated successfully!");

                            break;
                        }


                    case "13":
                        {
                            Console.WriteLine("Select Course:");
                            for (int i = 0; i < courses.Count; i++)
                                Console.WriteLine($"{i + 1}. {courses[i].Title}");
                            int cIndex = int.Parse(Console.ReadLine()) - 1;
                            Course selectedCourse = courses[cIndex];

                            var exams = selectedCourse.GetExams();
                            if (exams.Count == 0)
                            {
                                Console.WriteLine("No exams in this course.");
                                break;
                            }
                            Console.WriteLine("Select Exam:");
                            for (int i = 0; i < exams.Count; i++)
                                Console.WriteLine($"{i + 1}. {exams[i].Title}");
                            int eIndex = int.Parse(Console.ReadLine()) - 1;
                            Exam selectedExam = exams[eIndex];

                            if (selectedExam.questions.Count == 0)
                            {
                                Console.WriteLine("No questions in this exam.");
                                break;
                            }
                            Console.WriteLine("Select Question to remove:");
                            for (int i = 0; i < selectedExam.questions.Count; i++)
                                Console.WriteLine($"{i + 1}. {selectedExam.questions[i].Text}");
                            int qIndex = int.Parse(Console.ReadLine()) - 1;

                            var removedQuestion = selectedExam.questions[qIndex];
                            selectedExam.questions.RemoveAt(qIndex);
                            Console.WriteLine($"Question '{removedQuestion.Text}' removed successfully!");
                            break;
                        }





                    case "14":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid option!");
                            break;
                    }
                }
            }
        }
    }


