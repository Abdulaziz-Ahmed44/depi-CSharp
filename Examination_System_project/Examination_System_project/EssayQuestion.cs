using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System_project
{
    internal class EssayQuestion : Question
    {

        //constuctor
        public EssayQuestion(int id, string text, decimal mark) : base(id, text, mark)
        { }

        //methods
        public override bool? CheckAnswer(object answer)
        {
            return null;
        }
    }



}
