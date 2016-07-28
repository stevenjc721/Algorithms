/*
 * @author Steven J Carver
 * 
 * Example of Heap Sort.
 * 
 * Example Input:
 * 23, 3, 2, 34, 6
 * 
 * Output:
 * 34, 23, 6, 3, 2
 * 
 * Heap Sort:
 * Unstable
 * Asymptotic complexity O(n log n)
 * Complexity is guaranteed (more predictable than QuickSort) 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unsorted Array of ints
            int[] iArray = new int[22] { 4, 13, 11, 2, 7, 5, 14, 3, 18, 12, 1, 19, 6, 9, 17, 20, 10, 15, 8, 16, 0, -1 };

            hSort(iArray); //Sort Array

            //Print Sorted Array
            foreach (var x in iArray)
            {

                Console.Out.WriteLine(x);
            }
            Console.ReadLine();
        }

        //Heap Sort descending order
        static void hSort(int[] array){
            
            //Array sorted
            if (array.Length < 1){

                return;
            }

            int size = array.Length;

            //Create Binary Heap top half 
            for (int i = (size/2) - 1; i >= 0; i--){
                sift(array, size - 1, i);
            }
            //Create Binary Heap bottom half
            for (int i = size - 1; i > 0; i--){
                swap(array, 0, i);
                sift(array, i - 1, 0);
            }
        }

        //Bottom up Heapsort
        private static void sift(int[] array, int size, int index){

            int temp = array[index];
            int cIndex = (index*2) + 1;

            //Determine which child is greater for initial case
            if (cIndex < size && array[cIndex] > array[cIndex + 1]){
                cIndex++;
            }

            //verify still in bounds and modify depending on greatest child
            while (cIndex <= size && temp > array[cIndex]){

                array[index] = array[cIndex];
                index = cIndex;
                cIndex = (cIndex*2) + 1;

                //Determine which child is greater
                if (cIndex < size && array[cIndex] > array[cIndex + 1]){
                    cIndex++;
                }
            }
            array[index] = temp;
        }

        //Simple swap for element at index left and index right
        private static void swap(int[] array, int left, int right){

            int temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }
    }
}
