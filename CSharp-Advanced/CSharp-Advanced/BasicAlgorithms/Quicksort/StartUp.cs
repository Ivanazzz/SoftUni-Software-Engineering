using System;

namespace Quicksort
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 55, 33, 12, 18, -10 };
            Console.WriteLine(string.Join(", ", array));

            QuickSorter.QuickSort(array, 0, array.Length - 1);
            Console.WriteLine(string.Join(", ", array));
        }
    }

    public class QuickSorter
    {
        public static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end || end < 0 || start < 0)
            {
                return;
            }

            int pivotIndex = Partition(array, start, end);

            QuickSort(array, start, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, end);
        }

        private static int Partition(int[] array, int start, int end)
        {
            int pivot = array[end];
            int pivotIndex = start;

            for (int i = start; i < end; i++)
            {
                if (array[i] <= pivot)
                {
                    Swap(array, i, pivotIndex);
                    pivotIndex++;
                }
            }

            Swap(array, pivotIndex, end);

            return pivotIndex;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
