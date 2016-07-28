/*
 * @author Steven J Carver
 * 
 * Example of Radix Sort for array of strings or ints using a counting sort.
 * 
 * Example Input:
 * ABC, AAA, AAB, AAC, ACA
 * 
 * Output:
 * AAA, AAB, AAC, ABC, ACA
 * 
 * Radix Sort:
 * Stable
 * Asymptotic complexity O(m C(n))
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadixSort{

    class Program{

        static void Main(string[] args){

            //Unsorted Arrays
            int[] iArray = new int[] { 123, 151, 234, 701, 181, 401, 924, 155, 233, 456, 735, 412, 6 };
            string[] sArray = new string[] { "MEL", "TOD", "TOM", "JAC", "CUB", "KOB", "KID", "PLY", "MIC", "ABC" };

            iArray = rSort(iArray, 3);
            sArray = rSort(sArray, 3);

            foreach (var x in iArray){

                Console.Out.WriteLine(x);
            }

            Console.Out.WriteLine();

            foreach (var x in sArray){

                Console.Out.WriteLine(x);
            }
            Console.ReadLine();
        }

        //RadixSort for int[] 
        private static int[] rSort(int[] array, int dimension){

            bool toEnd = true;// counter to control exit
            record[] toPass = new record[array.Length]; // use precreated struct
            int[] toReturn = new int[array.Length]; //value to return

            //Iterate through all values and add record in struct array
            for (int i = 0; i < array.Length; i++){

                toPass[i] = new record();
                toPass[i].Key = i; 
                toPass[i].Value = (array[i] / dimension) % 10;
                if (array[i] / dimension != 0){

                    toEnd = false;
                }
            }

            if (toEnd){

                return array;
            }
            //Implement countingSort
            record[] SortedDigits = CountingSort(toPass);

            //Iterate through returned array and assign values to array to be returned
            for (int i = 0; i < toReturn.Length; i++){

                toReturn[i] = array[SortedDigits[i].Key];
            }
            return rSort(toReturn, dimension * 10);
        }

        //Radix sort for string[]
        private static string[] rSort(string[] array, int dimension){

            bool toEnd = true; // counter to control exit
            record[] toPass = new record[array.Length]; // use precreated struct
            string[] toReturn = new string[array.Length]; //value to return
            // Starting at d and iterating backwards
            for (int i = dimension; i > 0; i--){

                //Convert each string at a given position to a char[] then pull the specific char located at i
                for (int x = 0; x < array.Length; x++){

                    char[] c = array[x].ToCharArray();
                    toPass[x] = new record();
                    toPass[x].Key = x;
                    toPass[x].Value = (((int)c[i - 1] - 64) / dimension) % 10;
                    if ((((int)c[i - 1] - 64) / dimension) != 0){
                        toEnd = false;
                    }

                }
                if (toEnd){

                    return array;
                }
                //Implement countingSort
                record[] SortedDigits = CountingSort(toPass);

                for (int x = 0; x < array.Length; x++){

                    toReturn[x] = array[SortedDigits[x].Key];
                }
            }
            return toReturn;
        }

        //Simple counting sort
        public static record[] CountingSort(record[] A){

            int[] B = new int[MaxValue(A) + 1];
            record[] C = new record[A.Length];

            for (int i = 0; i < B.Length; i++){

                B[i] = 0;
            }
            for (int i = 0; i < A.Length; i++){

                B[A[i].Value]++;
            }
            for (int i = 1; i < B.Length; i++){

                B[i] += B[i - 1];
            }
            for (int i = A.Length - 1; i >= 0; i--){

                int value = A[i].Value;
                int index = B[value];
                B[value]--;
                C[index - 1] = new record();
                C[index - 1].Key = i;
                C[index - 1].Value = value;
            }
            return C;
        }

        //Finding max value in array
        static int MaxValue(record[] arr){

            int Max = arr[0].Value;// initial value to compare

            //step through all values and compare with current max
            for (int i = 1; i < arr.Length; i++){

                if (arr[i].Value > Max){
                    Max = arr[i].Value;
                }
            }
            return Max;
        }

    }

    //Simple struct to handle string or int comparison
    struct record{

        int key;
        int value;

        public int Key{

            get{
                return key;
            }
            set{
                key = value;
            }
        }

        public int Value{
            get{
                return value;
            }
            set{
                this.value = value;
            }
        }
    }
}
