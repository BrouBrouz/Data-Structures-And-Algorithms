using System;
using System.Collections.Generic;
using System.Linq;

namespace DSA_Assignement2
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
                                          "    8  - Sort the DataBase\n" +
                                          "    9  - Get Max element\n" +
                                          "    10 - Get Min element\n" +
                                          "    11 - Exit\n\n" +

                                          "    Choose a task > ");
                exerciseSelected = CheckIfStringIsIntegerBetween(Console.ReadLine(), 1, 11);
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
                        Console.WriteLine("    8  - Sort the DataBase\n");
                        SortByStudentNumber();
                        break;
                    case 9:
                        Console.WriteLine("    9  - Get Max element\n");
                        GetMaxElement();
                        Console.ReadKey();
                        break;
                    case 10:
                        Console.WriteLine("    10 - Get Min element\n");
                        GetMinElement();
                        Console.ReadKey();
                        break;
                    case 11:
                        //Exit
                        break;
                    default:
                        break;
                }
            } while (exerciseSelected != 11);
        }

        static void PopulateWithSampleData()
        {
            Student student1 = new Student("Maxime", "Broussart", "209", 90);
            Student student2 = new Student("Alessio", "Landodo", "307", 93);
            Student student3 = new Student("Carlos", "Romeo", "918", 70);
            Student student4 = new Student("Sergi", "BigBorra", "791", 55);
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
            string list = "Number of students : " + dataList.Count + "\nCurrent data base : \n";
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

        public static int CheckIfStringIsIntegerBetween(string stringRead, int min, int max)
        {
            int integer;
            bool check = Int32.TryParse(stringRead, out integer);
            while (check == false || integer < min || integer > max)
            {
                if (check == false)
                {
                    Console.Write("Error, this is not a integer, please try again > ");
                }
                else
                {
                    Console.Write($"Error, the number must be between {min} and {max}, please try again > ");
                }
                string newTry = Console.ReadLine();
                check = Int32.TryParse(newTry, out integer);
            }
            return integer;
        }

        //Assignement 2
        static void SortByStudentNumber()
        {
            if (dataList.Count() > 1)
            {
                Console.Write("Choose a sort field : \n\n" +
                    "1 - Student Number\n" +
                    "2 - First Name\n" +
                    "3 - Last  Name\n" +
                    "4 - Average Score\n" +
                    " > ");
                int sortField = CheckIfStringIsIntegerBetween(Console.ReadLine(), 1, 4);

                Console.Write("\nChoose a sort direction : \n\n" +
                    "1 - increasing\n" +
                    "2 - decreasing\n" +
                    " > ");
                int sortDirection = CheckIfStringIsIntegerBetween(Console.ReadLine(), 1, 2);

                Student[] tab = new Student[dataList.Count];
                dataList.CopyTo(tab, 0);

                Student[] sortedTab = SortingAlgorithm(tab, sortField);

                dataList = new LinkedList<Student>();
                foreach (Student element in sortedTab)
                {
                    if (sortDirection == 1)
                    {
                        dataList.AddLast(element);
                    }
                    else
                    {
                        dataList.AddFirst(element);
                    }
                }
            }
        }

        static Student[] SortingAlgorithm(Student[] tab, int sortField)
        {
            //Insertion Sort by :

            //1-Student Number
            if (sortField == 1)
            {
                for (int a = 0; a < tab.Length; a++)
                {
                    Student temp = tab[a];
                    int b = a;
                    while (b > 0 && Convert.ToInt32(temp.StudentNumber) < Convert.ToInt32(tab[b - 1].StudentNumber))
                    {
                        tab[b] = tab[b - 1];
                        b--;
                    }
                    tab[b] = temp;
                }
            }
            //2-First Name
            else if(sortField == 2)
            {
                for(int a = 0; a< tab.Length;a++)
                {
                    Student temp = tab[a];
                    int b = a;
                    while(b>0 && String.Compare(temp.FirstName, tab[b-1].FirstName)<0)
                    {
                        tab[b] = tab[b - 1];
                        b--;
                    }
                    tab[b] = temp;
                }
            }
            //3-Last Name
            else if(sortField == 3)
            {
                for (int a = 0; a < tab.Length; a++)
                {
                    Student temp = tab[a];
                    int b = a;
                    while (b > 0 && String.Compare(temp.LastName, tab[b - 1].LastName) < 0)
                    {
                        tab[b] = tab[b - 1];
                        b--;
                    }
                    tab[b] = temp;
                }
            }
            //4-Averege Score
            else
            {
                for(int a = 0; a < tab.Length; a++)
                {
                    Student temp = tab[a];
                    int b = a;
                    while(b>0 && temp.AverageScore < tab[b-1].AverageScore)
                    {
                        tab[b] = tab[b - 1];
                        b--;
                    }
                    tab[b] = temp;
                }
            }

            return tab;
        }

        static void GetMaxElement()
        {
            if (dataList.Count != 0)
            {
                float maxScore = dataList.First().AverageScore;
                Student maxStudent = dataList.First();
                foreach (Student tempStudent in dataList)
                {
                    if (tempStudent.AverageScore >= maxScore)
                    {
                        maxStudent = tempStudent;
                        maxScore = tempStudent.AverageScore;
                    }
                }
                Console.WriteLine($"The student who has the best score is {maxStudent.FirstName} {maxStudent.LastName}. His average score is {maxScore}.");
            }
            else
            {
                Console.WriteLine("There is no student in the database.");
            }
        }

        static void GetMinElement()
        {
            if (dataList.Count != 0)
            {
                float minScore = dataList.First().AverageScore;
                Student minStudent = dataList.First();
                foreach (Student tempStudent in dataList)
                {
                    if (tempStudent.AverageScore < minScore)
                    {
                        minStudent = tempStudent;
                        minScore = tempStudent.AverageScore;
                    }
                }
                Console.WriteLine($"The student who has the lowest score is {minStudent.FirstName} {minStudent.LastName}. His average score is {minScore}.");
            }
            else
            {
                Console.WriteLine("There is no student in the database.");
            }
        }
    }
}