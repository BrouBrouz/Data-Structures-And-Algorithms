using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DSA_lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                Console.WriteLine(" ---------- BROUSSART MAXIME ----------\n");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("               LESSON 2                \n");
                System.Threading.Thread.Sleep(500);
                Console.Write("Menu :\n"
                                     + " 1  - Task 1 : Arrays\n"
                                     + " 2  - Task 2 : Longest word\n"
                                     + " 3  - Task 3 : Reverse Sentence\n"
                                     + "\n"
                                     + " 4  - Homework 1  : Work on an array\n"
                                     + " 5  - Homework 2  : Work on a stack\n"
                                     + " 6  - Homework 3  : Work on a queue\n"
                                     + " 7  - Homework 4  : Work on a list\n\n"
                                     + "Choose an exersice > ");
                int exerciseSelected = CheckIfStringIsPositiveInteger(Console.ReadLine());
                Console.Clear();
                switch (exerciseSelected)
                {
                    case 1:
                        Console.WriteLine("You chose : 1  - Task 1 : Arrays\n");
                        Task1_Arrays();
                        break;
                    case 2:
                        Console.WriteLine("You chose : 2  - Task 2 : Longest word\n");
                        Task2_LongestWord();
                        break;
                    case 3:
                        Console.WriteLine("You chose : 3  - Task 3 : Reverse Sentence\n");
                        Task3_reverseSentence();
                        break;
                    case 4:
                        Console.WriteLine("You chose : 4  - Homework 1 : Work on an array\n");
                        Homework1_WorkOnAnArray();
                        break;
                    case 5:
                        Console.WriteLine("You chose : 5  - Homework 2 : Work on a stack\n");
                        Homework2_WorkOnAStack();
                        break;
                    case 6:
                        Console.WriteLine("You chose : 6  - Homework 3 : Work on a queue\n");
                        Homework3_WorkOnAQueue();
                        break;
                    case 7:
                        Console.WriteLine("You chose : 7  - Homework 4 : Work on a list\n");
                        Homework4_WorkOnAList();
                        break;
                    default:
                        Console.WriteLine("Error : The number selected is out of range");
                        break;
                }
                Console.WriteLine("\nType Escape to leave or any other key to select another exercise.");
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Escape);
        }

        static int CheckIfStringIsPositiveInteger(string stringRead)
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

        private static void Task1_Arrays()
        {
            // Initialization
            string[] names = { "Max", "Alessio", "Carlos", "Sergi", "Booba" };
            DateTime[] bdays = new DateTime[names.Length];
            bdays[0] = new DateTime(2000, 09, 07);
            bdays[1] = new DateTime(1997, 06, 10);
            bdays[2] = new DateTime(1997, 12, 29);
            bdays[3] = new DateTime(1997, 01, 15);
            bdays[4] = new DateTime(1980, 04, 23);

            // User Input
            Console.Write("Please enter index (0-4) > ");
            int index = CheckIfStringIsPositiveInteger(Console.ReadLine());
            while (index > 4)
            {
                index = CheckIfStringIsPositiveInteger(Console.ReadLine());
            }

            // Program logic
            int day = bdays[index].Day;
            string periodPfMonth = "beginning";
            if (day >= 10) { periodPfMonth = "mid"; }
            if (day >= 22) { periodPfMonth = "end"; }
            string monthName = GetNameOfMonth(bdays[index].Month);

            // Output
            Console.WriteLine($"{names[index]} is born in the {periodPfMonth} of {monthName}");
        }

        private static string GetNameOfMonth(int month)
        {
            string monthName = "Unknown";
            if (month == 1) monthName = "January";
            if (month == 2) monthName = "February";
            if (month == 3) monthName = "March";
            if (month == 4) monthName = "April";
            if (month == 5) monthName = "May";
            if (month == 6) monthName = "June";
            if (month == 7) monthName = "July";
            if (month == 8) monthName = "August";
            if (month == 9) monthName = "September";
            if (month == 10) monthName = "October";
            if (month == 11) monthName = "November";
            if (month == 12) monthName = "December";

            return monthName;
        }

        private static void Task2_LongestWord()
        {
            string sentence = "Write a C# Sharp Program to display the following pattern using the alphabet.";

            string[] words = sentence.Split(' ');

            string longest = "";

            foreach (string word in words)
            {
                if (longest.Length < Cleanword(word).Length)
                {
                    longest = word;
                }
            }

            Console.WriteLine($"The longest word of the sentence is ''{longest}''");
        }

        private static string Cleanword(string word)
        {
            return word.Replace('.', ' ');
        }

        private static void Task3_reverseSentence()
        {
            //Initialization
            string sentence = "Display the pattern like pyramid using the alphabet.";

            //Program Logic
            string[] words = sentence.Split(' ');
            Stack<string> stack = new Stack<string>();

            foreach (string word in words)
            {
                stack.Push(Cleanword(word));
            }

            //Output
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }

        private static void Homework1_WorkOnAnArray()
        {
            // Initialization
            int[] primeNumber = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29 };

            // User Input
            Console.Write("Array of integer created, which number do you want to check in the list? > ");
            int number = CheckIfStringIsPositiveInteger(Console.ReadLine());

            // Program
            bool exist = false;
            foreach (int element in primeNumber)
            {
                if (element == number)
                {
                    exist = true;
                }
            }

            // Output
            if (exist == true)
            {
                Console.WriteLine($"The number {number} is present in the array");
            }
            else
            {
                Console.WriteLine($"The number {number} is not present in the array");
            }

            Console.Write("\nArray : ");
            foreach (int element in primeNumber)
            {
                Console.Write(element + " ");
            }
        }

        private static void Homework2_WorkOnAStack()
        {
            // Initialisation
            Stack<string> names = new Stack<string>();
            string name = " ";

            // User Input
            Console.WriteLine("Add 10 names > ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(" " + i + " : ");
                name = Console.ReadLine();
                names.Push(name);
            }
            Console.Write("\nStack of names created, which name do you want to check in the list? > ");
            name = Console.ReadLine();

            //Program
            bool exist = names.Contains(name);

            // Output
            if (exist == true)
            {
                Console.WriteLine($"The name {name} is present in the stack");
            }
            else
            {
                Console.WriteLine($"The name {name} is not present in the stack");
            }

            Console.Write("\nStack : ");
            while (names.Count > 0)
            {
                Console.Write(names.Pop() + " ");
            }
        }

        private static void Homework3_WorkOnAQueue()
        {
            // Initialisation
            Queue<string> names = new Queue<string>();
            string name = " ";

            // User Input
            Console.WriteLine("Add 10 names > ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(" " + i + " : ");
                name = Console.ReadLine();
                names.Enqueue(name);
            }
            Console.Write("\nQueue of names created, which name do you want to check in the list? > ");
            name = Console.ReadLine();

            //Program
            bool exist = names.Contains(name);

            // Output
            if (exist == true)
            {
                Console.WriteLine($"The name {name} is present in the stack");
            }
            else
            {
                Console.WriteLine($"The name {name} is not present in the stack");
            }

            Console.Write("\nQueue : ");
            while (names.Count > 0)
            {
                Console.Write(names.Dequeue() + " ");
            }
        }

        private static void Homework4_WorkOnAList()
        {
            // Initialisation
            List<string> names = new List<string>();
            string name = " ";

            // User Input
            Console.WriteLine("Add 10 names > ");
            for (int i = 1; i < 11; i++)
            {
                Console.Write(" " + i + " : ");
                name = Console.ReadLine();
                names.Add(name);
            }
            Console.Write("\nList of names created, which name do you want to check in the list? > ");
            name = Console.ReadLine();

            //Program
            bool exist = names.Contains(name);

            // Output
            if (exist == true)
            {
                Console.WriteLine($"The name {name} is present in the stack");
            }
            else
            {
                Console.WriteLine($"The name {name} is not present in the stack");
            }

            Console.Write("\nList : ");
            for (int i = 0; i < names.Count; i++)
            {
                Console.Write(names[i] + " ");
            }
        }
    }
}
