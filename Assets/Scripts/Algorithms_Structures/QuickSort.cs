using System;
using UnityEngine;

namespace Utility {
    public class QuickSort {

        public static void Sort(EmployeeData.Employee[] inArray, int low = 0, int high = 0) {
            if(high == 0) {
                high = inArray.Length - 1;
            }

            if(low < high) {
                int pivotIndex = Partition(inArray, low, high);
                Sort(inArray, low, pivotIndex-1);
                Sort(inArray, pivotIndex + 1, high);
            }
        }

        private static int Partition(EmployeeData.Employee[] inArray, int low, int high) {
            EmployeeData.Employee pivot = inArray[high];
            int i = low - 1;

            for(int j = low; j < high; j++) {
                if(inArray[j].LastEntranceInEngineRoom <= pivot.LastEntranceInEngineRoom) {
                    i++;

                    EmployeeData.Employee temp = inArray[i];
                    inArray[i] = inArray[j];
                    inArray[j] = temp;
                }
            }

            EmployeeData.Employee tempPivot = inArray[i + 1];
            inArray[i + 1] = inArray[high];
            inArray[high] = tempPivot;

            return i + 1;
        }
    }
}
