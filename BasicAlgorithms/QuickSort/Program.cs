/*
 * @author Steven J Carver
 * 
 * Example of Quick Sort.
 * 
 * Example Input:
 *         23, 3, 2, 34, 6
 *          23(pivot)
 *  34                  3, 2, 6
 *  34(base case)         3(pivot)
 *               6(base case)    2(base case)
 * Output:
 * 34, 23, 6, 3, 2
 * 
 * Quick Sort:
 * Unstable
 * Based on Divide and Conquer
 * Asymptotic complexity O(n^2)
 * Expected complexity is O(n * log n)
 * Typically preforms better than Heap and Merge Sort
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort{

    class Program{

        static void Main(string[] args){

            //Unsorted Array of ints
            int[] iArray = new int[22] { 4, 13, 11, 2, 7, 5, 14, 3, 18, 12, 1, 19, 6, 9, 17, 20, 10, 15, 8, 16, 0, -1 };

            qSort(iArray); //Quick Array

            //Print Quick Array
            foreach (var x in iArray){
                
                Console.Out.WriteLine(x);
            }
            Console.ReadLine();
        }

        //Initial Step: Get values for recursion
        //I prefer to seperate base call from recursion, this is a personal preferences and not needed.
        static void qSort(int[] array){

            int left = 0;

            int right = array.Length - 1;

            qSort(array, left, right);

        }

        //Quick Sort
        //We first pick a random element and this becomes our pivot.
        //From the select pivot we reorganize the array so that all the elements that have a greater value than our pivot are placed to the left
        //of our pivot. All the elements with a lower value are placed after the pivot, or on the right.
        //For this example we will use a recursive approach, an iterative approach is also possible.
        //Our program will now make a recursive call and repeat the procedure until our subproblem size = 1.
        //When we reach this case our problem can we solved trivially. If we have one element it is already sorted.
        //Sorted in descending order.
        public static void qSort(int[] array, int left, int right){

            if (left < right){

                int pivot = left;
                
                //We examine elements to the right of our pivot. Because in this case our pivot is our first element
                for (int i = left + 1; i < right; i++){

                    //If the current element is greater than our pivot, we push the element to the left
                    if (array[i] > array[left]){

                        swap(array, i, ++pivot);
                    }
                }
                //Place our pivot element on the greatest index on the left
                swap(array, left, pivot);

                //Recursive call to sort elements to the left of our pivot
                qSort(array, left, pivot);
                //Recursive call to sort elements to the right of our pivot
                qSort(array, pivot + 1, right);
            }
        }

        //Simple swap for element at index left and index right
        private static void swap(int[] array, int left, int right){

            int temp = array[right];
            array[right] = array[left];
            array[left] = temp;
        }
    }
}
