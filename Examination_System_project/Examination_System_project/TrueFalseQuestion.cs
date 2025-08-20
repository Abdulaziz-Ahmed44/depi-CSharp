using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System_project
{
    internal class TrueFalseQuestion : Question
    {
        //properties
        public bool Correct { get; set; }

        //constructor
        public TrueFalseQuestion(int id, string text, decimal mark, bool correct) : base(id, text, mark)
        {
            Correct = correct;
        }
        //methods
        public override bool? CheckAnswer(object answer)
        {
            if (answer is bool userAnswer)
            {
                return userAnswer == Correct;
            }
            return false;
        }
    }




}
