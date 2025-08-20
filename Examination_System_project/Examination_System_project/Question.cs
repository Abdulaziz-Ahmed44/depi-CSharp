using System;

namespace Examination_System_project
{
    internal abstract class Question
    {
        //fields
        private int _id;
        private string _text;
        public decimal _mark;


        //properties
        public int Id
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


        public string Text
        {
            get
            {
                return _text;
            }
             set
            {
                if (string.IsNullOrWhiteSpace(value) || (value.Length < 50 || value.Length > 700))
                {
                    Console.WriteLine("Invalid Title Question.");
                }
                else
                {
                    _text = value;
                }
            }

        }


        //constructor
        public Question(int id, string text, decimal mark)
        {
            Id = id;
            Text = text;
            _mark = mark;
        }

        //methods

        public void SetMark(decimal mark, decimal totalExamMarks, decimal courseMaxDegree)
        {
            if (mark <= 0)
                Console.WriteLine("Mark must be greater than 0.");

            else if (totalExamMarks + mark > courseMaxDegree)
                Console.WriteLine("Total exam marks exceed course maximum degree.");
            else

                _mark = mark;

        }
        public void UpdateQuestion(string newText, decimal newMark)
        {
            _text = newText;  
            _mark = newMark;  
        }
        public abstract bool? CheckAnswer(object answer);
    }
}
