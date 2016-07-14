/*
 * @author Steven J Carver
 * 
 * Example of Shell Sort.
 * 
 * Example Input:
 * 23, 3, 2, 34, 6
 * 
 * Output:
 * 2, 3, 6, 23, 34
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShellSort
{
    class Program
    {
        static void Main(string[] args)
        {
            //Unsorted Array of ints
            int[] iArray = new int[22] {4, 13, 11, 2, 7, 5, 14, 3, 18, 12, 1, 19, 6, 9, 17, 20, 10, 15, 8, 16, 0, -1};

            sSort(iArray); //Sort Array

            //Print Sorted Array
            foreach (var x in iArray)
            {

                Console.Out.WriteLine(x);
            }
            Console.ReadLine();
        }

        //Sort Array based on Shell Sort
        // A traditional insertion sort will maintain a list of already sorted elements
        // Then it picks an element that isn't already in the list and places it in the correct position
        // It iteratively repeats this procedure for each element.
        // Shell Sort is similiar except it operates analogously.
        // The main difference is the use of increments. 
        // Unlike the traditional insertion sort, for every step only elements at some distance are compared.
        // This distance starts out large, ideally n/2, and will get smaller for each step.
        // The final execution will be that of a traditional insertion sort.
        static void sSort(int[] array)
        {

            //Array length
            int length = array.Length;

            //initial increment to use to sort
            int increment = (length)/2;

            int j, temp = 0;

            while (increment > 0){

                for (int i = 0; i < length; i++){

                    j = i;
                    //Our initial value to compare
                    temp = array[i];

                    //Comparing only within our increment && if our current value is less than the compared we swap them
                    while ((j >= increment) && array[j - increment] > temp){

                        array[j] = array[j - increment];
                        j = j - increment; // Reset our position and break out of the loop when comparison is complete
                    }

                    array[j] = temp;
                }
                //increment management after each iteration
                if (increment == 1){
                    //If increment = 1 we have just completed a traditional insertion sort
                    increment = 0;

                }
                else if (increment/2 >= 1){

                    // As long as increment is >= 2 we step down to a smaller increment.
                    increment = increment/2;
                }
            }
        }
    }
}
