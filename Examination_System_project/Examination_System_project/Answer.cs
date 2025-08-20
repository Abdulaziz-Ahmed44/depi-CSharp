namespace Examination_System_project
{
    internal class Answer
    {

        //properties
        public Question Question { get; set; }
        public object Response { get; set; }
        public int? ManualMark { get; set; }

        //methods
        public void AssignManualMark(int mark)
        {
            if (mark < 0 || mark > Question._mark)
                Console.WriteLine($"The required score is between 0 and {Question._mark}");

            ManualMark = mark;
        }

    }


}
