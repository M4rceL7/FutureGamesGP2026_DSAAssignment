using System;
using System.Collections.Generic;

namespace Utility {
    public class BinarySearch<T, U> {
        public static List<T> binarySearch(T[] inArray, U start, U end) {
            int low = 0;
            int high = inArray.Length - 1;
            int median = low + (low - high) / 2;

            while (low <= high) {
                
                if() {
                    return median;
                }
            }

            if() {
                low = median + 1;
            }
            else {
                high = median - 1;
            }

            return -1;
        }

        public static List<T> binarySearch(T[] inArray, U x) {

        }
    }
}
