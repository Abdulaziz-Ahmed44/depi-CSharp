using System;

namespace Examination_System_project
{

    internal abstract class Person
    {

        //fields
        protected int _id;
        protected string _name;




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


        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (_name != value || string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    Console.WriteLine("Invalid Name");
                }
                else
                {
                    _name = value;
                }
            }
        }

        //constructor
        public Person(int id, string name)
        {
            Id = id;
            Name = name;


        }
    }
}
