using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Examination_System_project
{
    internal class MCQQuestion : Question
    {
        //properties
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }

        //constuctor
        public MCQQuestion(int id, string text, decimal mark) : base(id, text, mark)
        {
            Options = new List<string>();
        }

        //methods
        public override bool? CheckAnswer(object answer)
        {
            if (answer is int selectedIndex)
            {
                return selectedIndex == CorrectIndex;
            }
            return false;
        }
    }
}


    

