using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace DSA_Lesson3
{
    internal class Program
    {
        private static List<int> listItems = new List<int>();
        public static bool[,] matrix;
        static Dictionary<string, int> phoneBook = new Dictionary<string, int>();

        static void Main(string[] args)
        {
            //EXAMPLES IN CLASS

            //StudentMarks();
            //SortedDict();

            ConsoleKeyInfo cki;
            do
            {
                Console.Clear();
                Console.WriteLine(" ---------- BROUSSART MAXIME ----------\n");
                System.Threading.Thread.Sleep(500);
                Console.WriteLine("               LESSON 3                \n");
                System.Threading.Thread.Sleep(500);
                Console.Write("Menu :\n"
                                     + " 1  - Task 1 : Items of a list\n"
                                     + " 2  - Task 2 : Program that count\n"
                                     + " 3  - Task 3 : Remove Odds\n"
                                     + " 4  - Task 4 : Program that counts each word of a text"
                                     + "\n"
                                     + " 5  - Homework 1  : Minesweeper game\n"
                                     + " 6  - Homework 2  : Phonebook\n\n"
                                     + "Choose an exersice > ");
                int exerciseSelected = CheckIfStringIsPositiveInteger(Console.ReadLine());
                Console.Clear();
                switch (exerciseSelected)
                {
                    case 1:
                        Console.WriteLine("You chose : 1  - Task 1 : Items of a list\n");
                        MenuList();
                        break;
                    case 2:
                        Console.WriteLine("You chose : 2  - Task 2 : Program that count\n");
                        CountArrayElements();
                        break;
                    case 3:
                        Console.WriteLine("You chose : 3  - Task 3 : Remove Odds\n");
                        RemoveOdds();
                        break;
                    case 4:
                        Console.WriteLine("You chose : 4  - Task 4 : Program that counts each word of a text\n");
                        Task04_WordsInAText();
                        break;
                    case 5:
                        Console.WriteLine("You chose : 5  - Homework 1 : Minesweeper game\n");
                        Homework1_MultidimensionalArray();
                        break;
                    case 6:
                        MenuPhonebook();
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
                Console.Write("Error, this is not an integer (int), please try again > ");
                string newTry = Console.ReadLine();
                check = Int32.TryParse(newTry, out integer);
            }
            return integer;
        }

        //In class Activities

        private static void SortedDict()
        {
            string text = "a text some text just some text";
            IDictionary<string, int> wordsCount = new SortedDictionary<string, int>();

            string[] words = text.Split(' ');
            foreach (string word in words)
            {
                int count = 1;
                if (wordsCount.ContainsKey(word))
                {
                    count = wordsCount[word] + 1;
                }
                wordsCount[word] = count;
            }

            foreach (var w in wordsCount)
            {
                Console.WriteLine($"Word {w.Key}, count = {w.Value}");
            }
        }

        private static void StudentMarks()
        {
            Dictionary<string, int> studentMarks = new Dictionary<string, int>();

            studentMarks.Add("Jane", 90);
            studentMarks.Add("Join", 80);
            studentMarks.Add("Ivan", 70);
            studentMarks.Add("Peter", 60);
            studentMarks.Add("Maria", 50);

            while (true)
            {
                foreach (KeyValuePair<string, int> studentMark in studentMarks)
                {
                    Console.WriteLine($"Student {studentMark.Key}, mark {studentMark.Value}");
                }
                Console.WriteLine("-----------------------------");


                Console.Write("Name (type exit to exit) : ");
                string name = Console.ReadLine();

                if (name == "exit")
                {
                    break;
                }

                if (studentMarks.ContainsKey(name))
                {
                    Console.WriteLine($"Student '{name}' score is {studentMarks[name]}.");
                }
                //if (studentMarks.TryGetValue(name, out int value))
                //{
                //    Console.WriteLine($"Student '{name}' score is {value}.");
                //}
                else
                {
                    Console.WriteLine($"Student '{name}' does not exists.");
                }
            }
        }

        private static void MenuList()
        {
            int choice = 0;
            while (choice != 4)
            {
                Console.Clear();
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. List all Items");
                Console.WriteLine("4. Exit");

                Console.Write("Your choice > ");

                choice = CheckIfStringIsPositiveInteger(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddItem();
                        break;
                    case 2:
                        RemoveItem();
                        break;
                    case 3:
                        DisplayItems();
                        break;
                    case 4:
                        break;
                    default:
                        Console.Write("The number selected correspond to any option.");
                        break;
                }
            }
        }

        private static void AddItem()
        {
            Console.Write("Item to add > ");
            int item = CheckIfStringIsPositiveInteger(Console.ReadLine());
            listItems.Add(item);
        }

        private static void RemoveItem()
        {
            Console.Write("Item to Remove > ");
            int item = CheckIfStringIsPositiveInteger(Console.ReadLine());
            listItems.Remove(item);
        }

        private static void DisplayItems()
        {
            foreach (var item in listItems)
            {
                Console.WriteLine($"Item = {item}");
            }
            Console.Write("Press Enter to continue ... ");
        }

        static void CountArrayElements()
        {
            int[] numbers = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            IDictionary<int, int> numbersCount = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                int count = 1;
                if (numbersCount.ContainsKey(number))
                {
                    count += numbersCount[number];
                }
                numbersCount[number] = count;
            }

            foreach (var w in numbersCount)
            {
                Console.WriteLine($"Word {w.Key}, count = {w.Value}");
            }

            Console.WriteLine("All the number were : { 3, 4, 4, 2, 3, 3, 4, 3, 2 }");
        }

        static void RemoveOdds()
        {
            List<int> numbers = new List<int> { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2, 6, 6, 6 };
            IDictionary<int, int> numbersCount = new SortedDictionary<int, int>();

            foreach (int number in numbers)
            {
                int count = 1;
                if (numbersCount.ContainsKey(number))
                {
                    count = numbersCount[number] + 1;
                }
                numbersCount[number] = count;
            }

            foreach (var w in numbersCount)
            {
                if (w.Value % 2 == 1)
                {
                    while (numbers.Contains(w.Key)) { numbers.Remove(w.Key); }
                }
            }

            //List<int> list = new List<int>();
            //foreach (var w in numbersCount)
            //{
            //    if(w.Value %2 == 0)
            //    {
            //        list.Add(w.Key);
            //    }
            //}

            foreach (var w in numbers)
            {
                Console.WriteLine($"Number {w}");
            }
        }

        //Homework : Task 4 and Homework 1 and 2

        private static void Task04_WordsInAText()
        {
            string filename = "GivenText.txt";
            StreamReader readingFile = new StreamReader(filename);
            string line = "";
            string[] data = null;
            IDictionary<string, int> words = new SortedDictionary<string, int>();
            char plurial = 's';

            while (readingFile.Peek() > 0)
            {
                line = readingFile.ReadLine();
                line = line.ToLower();
                data = line.Split(' ', '?', ',', '.', '-', '!');

                foreach (string word in data)
                {
                    int count = 1;
                    if (words.ContainsKey(word))
                    {
                        count = words[word] + 1;
                    }
                    words[word] = count;
                }
            }

            Console.WriteLine("All the words and their occurences of the text are :");
            foreach (var element in words)
            {
                Console.Write($" -{element.Key} --> {element.Value} time");
                if (element.Value > 1)
                {
                    Console.Write(plurial);
                }
                Console.WriteLine("");
            }
        }

        //Homework 1
        public static void Homework1_MultidimensionalArray()
        {
            Console.Write("Type the size of the table for the minesweeper game > ");
            int size = CheckIfStringIsPositiveInteger(Console.ReadLine());
            while (size > 50 || size <= 0)
            {
                Console.Write("The number entered is not valid, enter a size between 1 and 50");
                size = CheckIfStringIsPositiveInteger(Console.ReadLine());
            }
            matrix = new bool[size, size];
            Random randomChoice = new Random();
            int mineOrNoMine;
            int x;
            int y;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    mineOrNoMine = randomChoice.Next(-1, 1);
                    if (mineOrNoMine == 0)
                    {
                        matrix[i, j] = false;
                    }
                    else
                    {
                        matrix[i, j] = true;
                    }
                }
            }
            do
            {
                Console.Write("\nEnter the ligne coordinate > ");
                y = Between1AndLength(CheckIfStringIsPositiveInteger(Console.ReadLine()));
                Console.Write("Enter the colonne coordinate > ");
                x = Between1AndLength(CheckIfStringIsPositiveInteger(Console.ReadLine()));
                Console.Clear();
                DisplayMatrixOfMines(x, y);
                if (matrix[y, x] == false)
                {
                    Console.WriteLine("YEAH, there is no bomb ! Press any key to continue...");
                    Console.ReadKey();
                }
            } while (matrix[y, x] == false);
            Console.WriteLine("BOOM, there was a bomb!");
        }

        private static int Between1AndLength(int number)
        {
            while (number > matrix.GetLength(0) || number <= 0)
            {
                Console.Write("The number entered is not valid, enter a size between 1 and " + matrix.GetLength(1) + " > ");
                number = CheckIfStringIsPositiveInteger(Console.ReadLine());
            }
            return number - 1;
        }

        private static void DisplayMatrixOfMines(int x, int y)
        {
            Console.Write("   ");
            for (int a = 1; a <= matrix.GetLength(1); a++)
            {
                Console.Write(a + " ");
                if (a < 10) { Console.Write(" "); }
            }
            Console.WriteLine("");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.Write((i + 1) + " ");
                if (i < 9)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    if ((i == y) && (j == x))
                    {
                        if (matrix[i, j] == true)
                        {
                            Console.Write("#  ");
                        }
                        else
                        {
                            Console.Write("o  ");
                        }
                    }
                    else
                    {
                        Console.Write(".  ");
                    }
                }
                Console.WriteLine("");
            }
            Console.WriteLine("");
        }

        //Homework 2
        private static void MenuPhonebook()
        {
            int choice = 0;
            while (choice != 5)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the menu of the phone book, select an action : \n");
                Console.WriteLine("1. Insert a number");
                Console.WriteLine("2. Delete a number");
                Console.WriteLine("3. Search by name");
                Console.WriteLine("4. List all");
                Console.WriteLine("5. Exit");

                Console.Write("Your choice > ");

                choice = CheckIfStringIsPositiveInteger(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InsertANumber();
                        Console.ReadKey();
                        break;
                    case 2:
                        DeleteANumber();
                        Console.ReadKey();
                        break;
                    case 3:
                        SearchANumber();
                        Console.ReadKey();
                        break;
                    case 4:
                        ListAllNamesAndPhoneNumbers();
                        Console.ReadKey();
                        break;
                    case 5:
                        break;
                    default:
                        Console.Write("The number selected correspond to any option. Press any key to come back at the menu...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void InsertANumber()
        {
            Console.WriteLine("\nInsert a new contact into the phonebook : \n");
            Console.Write("Name of the contact > ");
            string name = Console.ReadLine();
            Console.Write("Phone number of the contact >  +359 ");
            int number = CheckIfStringIsPositiveInteger(Console.ReadLine());
            while (number > 999999999)
            {
                Console.Write("The phone number typed is not valid (only 9 digits). Please Try again >  +359 ");
                number = CheckIfStringIsPositiveInteger(Console.ReadLine());
            }
            phoneBook.Add(name, number);
            Console.Write("\nThe contact was successfuly added. Press any key to come back at the menu...");
        }

        private static void DeleteANumber()
        {
            Console.WriteLine("\nDelete a contact from the phonebook : \n");
            Console.Write("Name of the contact to delete > ");
            string name = Console.ReadLine();
            if (phoneBook.ContainsKey(name) == true)
            {
                phoneBook.Remove(name);
                Console.Write("\nThe contact was successfuly deleted. Press any key to come back at the menu...");
            }
            else
            {
                Console.Write("\nThe contact entered was not find in the phonebook. Press any key to come back at the menu...");
            }
        }

        private static void SearchANumber()
        {
            Console.WriteLine("\nSearch a contact from the phonebook : \n");
            Console.Write("Name of the contact to search > ");
            string name = Console.ReadLine();
            if (phoneBook.ContainsKey(name) == true)
            {
                Console.WriteLine($"The number of {name} is +359 {phoneNumber(phoneBook[name])}");
                Console.Write("\nPress any key to come back at the menu...");
            }
            else
            {
                Console.Write("\nThe contact entered was not find in the phonebook. Press any key to come back at the menu...");
            }
        }

        private static void ListAllNamesAndPhoneNumbers()
        {
            Console.WriteLine("\nList of all the phonebook contacts : \n");
            foreach (KeyValuePair<string, int> contact in phoneBook)
            {
                Console.WriteLine($" - Name : {contact.Key}");
                Console.WriteLine($"   Phone Number {phoneNumber(contact.Value)}");
                Console.WriteLine();
            }
            if (phoneBook.Count == 0)
            {
                Console.WriteLine("\nThere is no contact in the phone book. Press any key to come bak at the menu...");
            }
            else
            {
                Console.Write("\nPress any key to come back at the menu...");
            }
        }

        private static string phoneNumber(int phone)
        {
            string display = " +359 ";
            int number0 = 100000000;
            while(phone<number0)
            {
                display += "0";
                number0 /= 10;
            }
            display += phone;
            return display;
        }
    }
}