using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Lesson7
{
    public class Student
    {
        public string name;
        public int studentNumber;

        public string Name
        {
            get { return name; }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The name is empty");
                }
                name = value;
            }
        }

        public int StudentNumber
        {
            get { return studentNumber; }
            set
            {
                if (value <= 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("The student number must be between 10 000 and 99 999");
                }
                studentNumber = value;
            }
        }

        public override string ToString()
        {
            return $"Student name : {Name} - Student Number : {studentNumber}";
        }
    }
}
