using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DSA_Lesson7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            //var arrayToSort = GenerateArray(10000); 
            //Console.WriteLine($"Array created - timer = {stopwatch.ElapsedMilliseconds}");

            //stopwatch.Restart();
            //var array1 = BubbleSort(arrayToSort);
            //Console.WriteLine($"Bubble sort - timer = {stopwatch.ElapsedMilliseconds}");

            //stopwatch.Restart();
            //var array2 = SelectionSortMaximum(arrayToSort);
            //Console.WriteLine($"Selection sort Maximum - timer = {stopwatch.ElapsedMilliseconds}");

            //stopwatch.Restart();
            //var array3 = SelectionSortMinimum(arrayToSort);
            //Console.WriteLine($"Selection sort Minimum - timer = {stopwatch.ElapsedMilliseconds}");

            //Console.ReadLine();
            StudentAdministration.programTest();
        }

        private static int[] GenerateArray(int size)
        {
            int[] randomArray = new int[size];

            Random rnd = new Random();

            for (int i = 0; i < size; i++)
            {
                randomArray[i] = rnd.Next(1, 100000);
            }

            return randomArray;
        }

        private static int[] BubbleSort(int[] unsortedArray)
        {
            int[] arrayToSort = (int[])unsortedArray.Clone();

            int outer, inner;

            for (outer = arrayToSort.Length - 1; outer > 0; outer--) // counting down
            {
                for (inner = 0; inner < outer; inner++) // bubbling up
                {
                    if (arrayToSort[inner] > arrayToSort[inner + 1]) // if out of order...
                    {
                        // ...then swap
                        int temp = arrayToSort[inner];
                        arrayToSort[inner] = arrayToSort[inner + 1];
                        arrayToSort[inner + 1] = temp;
                    }
                }
            }

            return arrayToSort;
        }

        public static int[] SelectionSortMaximum(int[] unsortedArray)
        {
            int[] arrayToSort = (int[])unsortedArray.Clone();
            int maximum, inner, outer;

            for (outer = 0; outer < arrayToSort.Length -1 ; outer++)
            {
                maximum = outer;
                for(inner = outer + 1; inner < arrayToSort.Length - outer; inner++)
                {
                    if(arrayToSort[inner]<arrayToSort[maximum])
                    {
                        maximum = inner;
                    }
                }
                int temp = arrayToSort[outer];
                arrayToSort[outer] = arrayToSort[maximum];
                arrayToSort[maximum] = temp;
            }
           
            return arrayToSort;
        }

        public static int[] SelectionSortMinimum(int[] unsortedArray)
        {
            int[] arrayToSort = (int[])unsortedArray.Clone();
            int minimum, inner, outer;

            for (outer = 0; outer < arrayToSort.Length - 1; outer++)
            {
                minimum = outer;
                for (inner = outer + 1; inner < arrayToSort.Length; inner++)
                {
                    if (arrayToSort[inner] < arrayToSort[minimum])
                    {
                        minimum = inner;
                    }
                }
                int temp = arrayToSort[outer];
                arrayToSort[outer] = arrayToSort[minimum];
                arrayToSort[minimum] = temp;
            }

            return arrayToSort;
        }
    }
}
