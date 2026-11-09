using System;
using System.Collections.Generic;
using UnityEditor;

namespace Utility {
    public class BinarySearch {
        public static List<T> binarySearch<T, U>(T[] inArray, U start, U end, Func<T, U> getValue)
            where U : IComparable<U>
        {
            if(inArray.Length == 0)
                return null;

            int low = 0;
            int high = inArray.Length;
            int median;
            List<T> allInRange = new List<T>();

            while(low < high) {
                median = low + (high - low) / 2;

                if(getValue(inArray[median]).CompareTo(start) < 0) {
                    low = median + 1;
                }else {
                    high = median;
                }
            }
            int startIndex = low;
            high = inArray.Length;

            while (low < high) {
                median = low + (high - low) / 2;

                if(getValue(inArray[median]).CompareTo(end) <= 0) {
                    low = median + 1;
                }else {
                    high = median;
                }
            }

            int endIndex = low;

            for(int i = startIndex; i < endIndex; i++) {
                allInRange.Add(inArray[i]);
            }

            return allInRange;
        }

        public static int binarySearch<T, U>(T[] inArray, U toSearch, Func<T,U> getValue)
            //where T : class //Contraint if i want to return null.
            where U :IComparable<U>
            {
            if(inArray.Length == 0)
                return -1;

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
