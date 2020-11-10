using System;

namespace DSA_Lesson7
{
    public class StudentAdministration
    {
        public static void programTest()
        {
            Student[] students = generateArrayOfStudents(10);
            displayStudentsList(students);
            InsertionSortStudentsByNumbers(students);
            displayStudentsList(students);

            //Binary Search
            int position = BinarySearch(7, students);
            if (position == -1)
            {
                Console.WriteLine($"There is no students who has number 7 as a student number");
            }
            else
            {
                Console.WriteLine($"Student who has number 7 as a student number is the {position+1}th student of the tab");
            }
            Console.ReadKey();
        }

        public static Student[] generateArrayOfStudents(int size)
        {
            Student[] array = new Student[size];
            
            string studentName;
            Random rand = new Random();

            for (int i = 1; i < size+1; i++)
            {
                studentName = $"John {i}";
                if (i < 10)
                {
                    studentName += " ";
                }
                if (i < 100)
                {
                    studentName += " ";
                }
                array[i-1] = new Student
                {
                    name = studentName,
                    studentNumber = rand.Next(1,10)
                };
            }

            return array;
        }

        public static void InsertionSortStudentsByNumbers(Student[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                /*storing current element whose left side is checked for its  correct position .*/
                Student student = array[i];
                int counter = i;

                /* check whether the adjacent element in left side is greater or less than the current element. */
                while ((counter > 0) && (student.StudentNumber < array[counter-1].StudentNumber))
                {
                    array[counter] = array[counter-1];
                    counter--;
                }
                // moving current element to its  correct position.
                array[counter] = student;
            }
        }

        public static void displayStudentsList(Student[] students)
        {
            for (int a = 0; a < students.Length; a++)
            {
                Console.WriteLine(students[a]);
            }
            Console.WriteLine();
        }

        public static int BinarySearch(int element, Student[] students)
        {
            int mid=-1;
            int start = 0;
            int end = students.Length;
            bool found = false;

            while((found == false) && (start<end))
            {
                mid = (start + end) / 2;
                if(students[mid].studentNumber == element)
                {
                    found = true;
                }
                else if (element > students[mid].StudentNumber)
                {
                    start = mid + 1;
                }
                else
                {
                    end = mid - 1;
                }
            }
            if(found == true)
            {
                return mid;
            }
            else
            {
                return -1;
            }
        }
        
    }
}
