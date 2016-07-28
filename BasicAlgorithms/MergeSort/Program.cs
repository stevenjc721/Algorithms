/*
 * @author Steven J Carver
 * 
 * Example of Merge Sort.
 * 
 * Example Input:
 *         23, 3, 2, 34, 6
 *      
 *       23, 3, 2        34, 6
 *      
 *     23, 3    2       34    6
 *     
 *    23   3
 *      
 *         23, 3, 2     34, 6
 *         
 *           34, 23, 6, 3, 2
 * Output:
 * 34, 23, 6, 3, 2
 * 
 * Merge Sort:
 * Stable
 * Based on Divide and Conquer
 * Asymptotic complexity O(n * log n)
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {

            //Unsorted Array of ints
            int[] iArray = new int[22] { 4, 13, 11, 2, 7, 5, 14, 3, 18, 12, 1, 19, 6, 9, 17, 20, 10, 15, 8, 16, 0, -1 };

            mSort(iArray); //Merge Array

            //Print Merge Array
            foreach (var x in iArray){

                Console.Out.WriteLine(x);
            }
            Console.ReadLine();
        }

        //Initial Step: Get values for recursion
        static void mSort(int[] array){

            int[] aux = new int[array.Length];
            int left = 0;

            int right = array.Length - 1;

            mSort(array, aux, left, right);

        }

        //Merge Sort
        public static void mSort(int[] array, int[] aux, int left, int right){

            //Base case
            if (left == right){

                return;
            }
            //identify current middle
            int middle = (left + right) / 2;
            
            //Recursive call to sort left side
            mSort(array, aux, left, middle);

            //Recursive call to sort right side
            mSort(array, aux, middle + 1, right);

            //Merging the left and right side together
            merge(array, aux, left, right);

            //Reorganizing our input array to match computed order
            for (int i = left; i <= right; i++){

                array[i] = aux[i];
            }
        }

        private static void merge(int[] array, int[] aux, int left, int right){

            //Current middle value
            int middle = (left + right)/2;
            
            //Copy of left index to be manipulated
            int lIndex = left;

            //Copy of right index to be manipulated
            int rIndex = middle + 1;

            //Current aux array index
            int aIndex = left;

            //While our left and right indexes are within their appropriate subarrays continue
            while (lIndex <= middle && rIndex <= right){

                //If value at left index >= value at right index set aux value for current aux Index and increase current left index
                if (array[lIndex] >= array[rIndex]){

                    aux[aIndex] = array[lIndex++];
                }
                //If previous case not true we step to our next value on the right subarray
                else{

                    aux[aIndex] = array[rIndex++];
                }
                //Step forward in our aux array for next value placement
                aIndex++;
            }

            //Case when for values not caught by previous cases
            while (lIndex <= middle){
                
                //If left values remain add to aux at the current aux Index and step forward
                aux[aIndex] = array[lIndex++];
                aIndex++;
            }
            //Case when for values not caught by previous cases
            while (rIndex <= right){
                //If right ralues remain, add to aux at the current aux Index and step forward 
                aux[aIndex] = array[rIndex++];
                aIndex++;
            }
        }
    }
}
