using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject
{
    public class Program
    {
        public static void Main(string[] pArguments)
        {
            int[] randomArray   = Program.GenerateRandomLargeArray();
            int[] arrayToSort1  = new int[10000];
            int[] arrayToSort2  = new int[10000];

            double bubbleSeconds    = 0;
            double quickSeconds     = 0;

            DateTime bubbleStart;
            DateTime bubbleEnd;
            DateTime quickStart;
            DateTime quickEnd;

            randomArray.CopyTo(arrayToSort1, 0);
            randomArray.CopyTo(arrayToSort2, 0);

            bubbleStart = DateTime.Now;
            Program.BubbleSort(arrayToSort1, arrayToSort1.Length);
            bubbleEnd = DateTime.Now;

            quickStart = DateTime.Now;
            Program.Quick_Sort(arrayToSort2, 0, arrayToSort2.Length - 1);
            quickEnd = DateTime.Now;

            bubbleSeconds   = (bubbleEnd - bubbleStart).TotalSeconds;
            quickSeconds    = (quickEnd - quickStart).TotalSeconds;

            Console.WriteLine("Time Calculations:");
            Console.WriteLine();
            Console.WriteLine("Bubblesort Start: " + bubbleStart.ToString("MM/dd/yyyy HH:mm:ss.FFF"));
            Console.WriteLine("Bubblesort End: " + bubbleEnd.ToString("MM/dd/yyyy HH:mm:ss.FFF"));
            Console.WriteLine();
            Console.WriteLine("Time: " + bubbleSeconds + " seconds.");
            Console.WriteLine();
            Console.WriteLine("Quicksort Start: " + quickStart.ToString("MM/dd/yyyy HH:mm:ss.FFF"));
            Console.WriteLine("Quicksort End: " + quickEnd.ToString("MM/dd/yyyy HH:mm:ss.FFF"));
            Console.WriteLine();
            Console.WriteLine("Time: " + quickSeconds + " seconds.");
            Console.WriteLine();

            if (bubbleSeconds > quickSeconds)
                Console.WriteLine("Quicksort is faster.");
            else
                Console.WriteLine("Bubblesort is faster.");
        }

        public static int[] GenerateRandomLargeArray()
        {
            int[]   result = new int[10000];
            Random  random = new Random();

            for (int i = 0; i < 10000; i++)
                result[i] = random.Next(1, 10000);

            return result;
        }

        public static int[] BubbleSort(int[] arrayToSort, int arrayLength)
        {
            // Iterate full array
            for (int i = 0; i < arrayLength - 1; i++)
            {
                // Iterate backwards until the spot is found
                for (int j = 0; j < arrayLength - i - 1; j++)
                {
                    // When spot is found swap
                    if (arrayToSort[j] > arrayToSort[j + 1])
                    {
                        int tempNumber = arrayToSort[j];

                        arrayToSort[j] = arrayToSort[j + 1];
                        arrayToSort[j + 1] = tempNumber;
                    }
                }
            }

            return arrayToSort;
        }

        private static void Quick_Sort(int[] arrayToSort, int left, int right)
        {
            if (left < right)
            {
                int pivot = Split(arrayToSort, left, right);

                if (pivot > 1)
                    Quick_Sort(arrayToSort, left, pivot - 1);
                if (pivot + 1 < right)
                    Quick_Sort(arrayToSort, pivot + 1, right);
            }
        }

        private static int Split(int[] arrayToSort, int left, int right)
        {
            int pivot = arrayToSort[left];

            while (true)
            {
                while (arrayToSort[left] < pivot)
                    left++;

                while (arrayToSort[right] > pivot)
                    right--;

                if (left < right)
                {
                    if (arrayToSort[left] == arrayToSort[right])
                        return right;
                    else
                    {
                        int tempValue = arrayToSort[left];

                        arrayToSort[left]   = arrayToSort[right];
                        arrayToSort[right]  = tempValue;
                    }
                }
                else
                    return right;
            }
        }
    }
}
