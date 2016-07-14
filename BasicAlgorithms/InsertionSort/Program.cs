/*
 * @author Steven J Carver
 * 
 * Example of Insertion Sort.
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

namespace InsertionSort{

    class Program{

        static void Main(string[] args){

            //Unsorted Array of ints
            int[] iArray = new int[22] {4, 13, 11, 2, 7, 5, 14, 3, 18, 12, 1, 19, 6, 9, 17, 20, 10, 15, 8, 16, 0, -1};

            iSort(iArray); //Sort Array

            //Print Sorted Array
            foreach (var x in iArray){

                Console.Out.WriteLine(x);
            }
            Console.ReadLine();
        }

        //Sort Array based on Insertion Sort
        //Similiar to Selection Sort in that you have two arrays a sorted and unsorted array.
        //We start by picking an item from the unsorted array and add it to the sorted array.
        //Then we pick another item from the unsorted array and compare it to the previously sorted values and place it in the appropriate position.
        static void iSort(int[] array){

            //length of array
            int length = array.Length;

            //Iterate through all values
            for (int i = 1; i < length; i++){

                int toSort = array[i]; // value from unsorted array to be added to sorted array
                int inserted = 0;

                //Iterate through all previous values to find correct position in sorted array
                for (int j = i - 1; j >= 0 && inserted != 1;){

                    //If our current max, array[j], is greater than our value to sort we swap our current max with our value to sort
                    if (array[j] > toSort){

                        array[j + 1] = array[j]; // push current max up
                        j--; // used to step down and validate the position of toSort
                        array[j + 1] = toSort; // push value to sort down

                    }else{
                        //If our current max is less than our value to sort do nothing
                        inserted = 1;
                    }
                }
            }
        }
    }
}
