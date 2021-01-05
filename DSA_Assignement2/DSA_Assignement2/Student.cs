using System;
using System.Linq;

namespace DSA_Assignement2
{
    public class Student
    {
        public Student()
        {
            Console.WriteLine("Creation of a new student : ");
            Console.Write("- Enter the first name > ");
            FirstName = CheckIfStringIsLessThan30(Console.ReadLine());
            Console.Write("- Enter the last name  > ");
            LastName = CheckIfStringIsLessThan30(Console.ReadLine());
            Console.Write("- Create a student number (that does not exist yet) > ");
            int studentNumber = Program.CheckIfStringIsIntegerBetween(Console.ReadLine(), 100, 999);
            while (Program.ExistAlready(studentNumber) == true)
            {
                Console.Write($"{studentNumber} is already used as a student number. Please try again > ");
                studentNumber = Program.CheckIfStringIsIntegerBetween(Console.ReadLine(), 100, 999);
            }
            StudentNumber = Convert.ToString(studentNumber);
            Console.Write("- Enter the average score of the student (0 to 100) > ");
            AverageScore = CheckIfStringIsAverageScore(Console.ReadLine());
        }

        public Student(string firstName, string lastName, string studentNumber, float averageScore)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentNumber = studentNumber;
            AverageScore = averageScore;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StudentNumber { get; set; }

        public float AverageScore { get; set; }

        public string CheckIfStringIsLessThan30(string value)
        {
            while (value.Count() >= 30 || value == null || value.Count()== 0)
            {
                if (value == null || value.Count() == 0)
                {
                    Console.Write("The name cannot be null. Please try again > ");
                    value = Console.ReadLine();
                }
                else
                {
                    Console.Write("The number of letter cannot be up to 30 characters. Please try again > ");
                    value = Console.ReadLine();
                }
            }
            return value;
        }

        public static float CheckIfStringIsAverageScore(string stringRead)
        {
            float number;
            bool check = float.TryParse(stringRead, out number);
            while (check == false || number < 0 || number > 100)
            {
                Console.Write("Error, this is not a possible average score (must between 0 and 100), please try again > ");
                string newTry = Console.ReadLine();
                check = float.TryParse(newTry, out number);
            }
            return number;
        }

        public override string ToString()
        {
            return $"The student {FirstName} {LastName} has for student number {StudentNumber} and an average score of {AverageScore}.";
        }
    }
}
