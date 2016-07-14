/*
 * @author Steven J Carver
 * 
 * Example of Selection Sort.
 * 
 * Example Input:
 * 23, 2, 3, 34, 6
 * 
 * Output:
 * 2, 3, 6, 23, 34
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;

namespace SelectionSort
{

    class Program
    {

        static void Main(string[] args)
        {

            //Unsorted Array of ints
            int[] iArray = new int[5] { 23, 2, 3, 34, 6 };

            sSort(iArray); //Sort Array

            //Print Sorted Array
            foreach (var x in iArray)
            {

                Console.Out.WriteLine(x);
            }
            Console.ReadLine();
        }

        //Sort Array based on Selection Sort
        //Data rearranged by finding the smallest value in the unsorted array
        //and switching it with the the last unsorted value. Visual below
        // Iteration   Unsorted Array           Sorted Array
        //    0        index 0 forwards         Empty
        //    1        index 1 forwards         index 0
        //    2        index 2 forwards         index 0, 1
        //    3        index 3 forwards         index 0, 1, 2
        // ...
        //  n - 1      index n - 2 forwards     index 0 - (n - 3)   
        //    n        index n - 1 forwards     index 0 - (n - 2)
        static void sSort(int[] array){

            //length of array
            int length = array.Length;

            //Step through the unsorted array
            for (int i = 0; i < length; i++){

                // We set the currentMin to the index for the first element in the unsorted array
                int currentMin = i;

                // We step through the remaining unsorted array and find the smalled int
                for (int j = i + 1; j < length; j++){

                    //When a smaller value is found we store our newest minimum value index
                    if (array[j] < array[currentMin]) currentMin = j;
                }

                //Prevent unnecessary assignment
                if (array[i] != array[currentMin]){

                    int toSwap = array[i];
                    array[i] = array[currentMin];
                    array[currentMin] = toSwap;
                }
            }
        }
    }

}
