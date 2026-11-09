using System;
using UnityEngine;

namespace Utility {
    public class QuickSort {

        public static void Sort(EmployeeData.Employee[] inArray) {
            if(inArray == null) {
                throw new ArgumentNullException(nameof(inArray));
            }

            QuickSortRecursive(inArray, 0, inArray.Length - 1);
        }

        private static void QuickSortRecursive(EmployeeData.Employee[] inArray, int low, int high) {
            if(low < high) {
                int pivotIndex = Partition(inArray, low, high);
                QuickSortRecursive(inArray, low, pivotIndex - 1);
                QuickSortRecursive(inArray, pivotIndex + 1, high);
            }
        }

        private static int Partition(EmployeeData.Employee[] inArray, int low, int high) {
            int randomIndex = UnityEngine.Random.Range(low, high + 1);

            EmployeeData.Employee tempRandom = inArray[randomIndex];
            inArray[randomIndex] = inArray[high];
            inArray[high] = tempRandom;

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
