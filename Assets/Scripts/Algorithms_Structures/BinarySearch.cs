using System;
using System.Collections.Generic;
using UnityEditor;

namespace Utility {
    public class BinarySearch {
        //public static int binarySearch<T, U>(T[] inArray, U start, U end) {

        //}

        public static int binarySearch<T, U>(T[] inArray, U toSearch, Func<T,U> getValue)
            //where T : class //Contraint if i want to return null.
            where U :IComparable<U>
            {
            int low = 0;
            int high = inArray.Length - 1;
            int median;

            while(low <= high) {
                median = low + (high - low) / 2;

                U currentValue = getValue(inArray[median]);
                int comparison = currentValue.CompareTo(toSearch);

                if(comparison == 0) {
                    return median;
                }

                if(comparison < 0) {
                    low = median + 1;
                }
                else {
                    high = median - 1;
                }
            }

            

            return -1;
        }
    }
}
