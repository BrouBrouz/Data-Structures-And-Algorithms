using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Assignement1
{
    public class Program
    {
        static LinkedList<Student> dataList = new LinkedList<Student>();

        public int Length
        {
            get { return dataList.Count; }
        }

        public Student First
        {
            get { return dataList.First(); }
        }

        public Student Last
        {
            get { return dataList.Last(); }
        }

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WindowHeight = 45;
            Console.WindowWidth = 130;
            int exerciseSelected = 1;
            do
            {
                Console.Clear();
                Console.Write(DisplayAllTheList() +
                                          "    1  - Populate with sample Data\n" +
                                          "    2  - Add\n" +
                                          "    3  - Get element (get written informations about a student)\n" +
                                          "    4  - Remove by student number\n" +
                                          "    5  - Remove first\n" +
                                          "    6  - Remove last\n" +
                                          "    7  - Clear the DataBase\n" +
                                          "    8  - Exit\n\n" +

                                          "    Choose a task > ");
                exerciseSelected = CheckIfStringIsPositiveInteger(Console.ReadLine());
                Console.Clear();
                Console.Write(DisplayAllTheList());
                switch (exerciseSelected)
                {
                    case 1:
                        Console.WriteLine("    1  - Populate with sample Data\n");
                        PopulateWithSampleData();
                        break;
                    case 2:
                        Console.WriteLine("    2  - Add\n");
                        Add(new Student());
                        break;
                    case 3:
                        if (dataList.Count != 0)
                        {
                            Console.WriteLine("    3  - Get element (get written informations about a student)\n");
                            Console.Write(GetElement());
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.WriteLine("    4  - Remove by student number\n");
                        RemoveByIndex();
                        break;
                    case 5:
                        Console.WriteLine("    5  - Remove first\n");
                        RemoveFirst();
                        break;
                    case 6:
                        Console.WriteLine("    6  - Remove last\n");
                        RemoveLast();
                        break;
                    case 7:
                        Console.WriteLine("    7  - Clear the DataBase\n");
                        dataList.Clear();
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Error : There is no task that correspond to number " + exerciseSelected);
                        break;
                }
            } while (exerciseSelected != 8);
        }

        static void PopulateWithSampleData()
        {
            Student student1 = new Student("Maxime", "Broussart", "209", 92);
            Student student2 = new Student("Alessio", "Landodo", "307", 98);
            Student student3 = new Student("Carlos", "Romeo", "918", 89);
            Student student4 = new Student("Sergi", "BigBorra", "791", 87);
            dataList.AddFirst(student4);
            dataList.AddFirst(student3);
            dataList.AddFirst(student2);
            dataList.AddFirst(student1);
        }

        static void Add(Student element)
        {
            dataList.AddLast(element);
        }

        static Student GetElement()
        {
            bool found = false;
            Student student = null;
            while (found == false)
            {
                Console.Write("Type the student number > ");
                string answer = Console.ReadLine();
                foreach (Student element in dataList)
                {
                    if (element.StudentNumber == answer)
                    {
                        student = element;
                        found = true;
                    }
                }
                if (found == false)
                {
                    Console.Write($"The student number {answer} was not find. Please try again. ");
                }
            }
            return student;
        }

        static void RemoveByIndex()
        {
            if (dataList.Count != 0)
            {
                Console.Write("Which student do you want to remove? ");
                Student studentToRemove = GetElement();
                dataList.Remove(studentToRemove);
                Console.WriteLine($"Student {studentToRemove.FirstName} {studentToRemove.LastName} was well removed.");
            }
        }

        static void RemoveFirst()
        {
            if (dataList.Count != 0)
            {
                dataList.RemoveFirst();
            }
        }

        static void RemoveLast()
        {
            if (dataList.Count != 0)
            {
                dataList.RemoveLast();
            }
        }

        static string DisplayAllTheList()
        {
            string list = "Number of students : "+ dataList.Count +"\nCurrent data base : \n";
            list += " _________________________________________________________________________________________________________________\n" +
                    "|   Student Number   |          First Name          |           Last Name          |         Average Score        |\n" +
                    "|____________________|______________________________|______________________________|______________________________|\n";
            foreach (Student student in dataList)
            {
                list += "|" + DisplayALineOfStudentTab(student.StudentNumber, 19) + "|";
                list += DisplayALineOfStudentTab(student.FirstName, 30) + "|";
                list += DisplayALineOfStudentTab(student.LastName, 30) + "|";
                list += DisplayALineOfStudentTab(student.AverageScore.ToString(), 30) + "|\n";
            }
            list += "|____________________|______________________________|______________________________|______________________________|\n\n";
            return list;
        }

        static string DisplayALineOfStudentTab(string text, int largeSize)
        {
            string line = "";
            int numberOfLetters;
            numberOfLetters = text.Count();
            numberOfLetters = (largeSize - numberOfLetters) / 2;
            for (int i = 0; i < numberOfLetters; i++)
            {
                line += " ";
            }
            line += text;
            for (int i = 0; i < numberOfLetters; i++)
            {
                line += " ";
            }
            if (text.Count() % 2 == 1)
            {
                line += " ";
            }
            return line;
        }

        public static bool ExistAlready(int studentNumberInt)
        {
            string studentNumberString = studentNumberInt.ToString();
            bool exist = false;
            foreach (Student element in dataList)
            {
                if (element.StudentNumber == studentNumberString)
                {
                    exist = true;
                }
            }
            return exist;
        }

        public static int CheckIfStringIsPositiveInteger(string stringRead)
        {
            int integer;
            bool check = Int32.TryParse(stringRead, out integer);
            while (check == false || integer < 0)
            {
                Console.Write("Error, this is not a positive integer, please try again > ");
                string newTry = Console.ReadLine();
                check = Int32.TryParse(newTry, out integer);
            }
            return integer;
        }
    }
}
