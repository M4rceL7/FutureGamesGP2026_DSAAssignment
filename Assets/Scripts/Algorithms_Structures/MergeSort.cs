using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {
    public class MergeSort<T> {

        public static T[] Sort(T[] inArray, IComparer<T> comparer) {

            if(inArray == null)
                return null;

            if(inArray.Length <= 1)
                return inArray;

            int middle = inArray.Length / 2;

            T[] L = new T[middle];
            T[] R = new T[inArray.Length - middle];

            for(int i = 0; i < middle; i++)
                L[i] = inArray[i];

            for(int i = middle; i < inArray.Length; i++)
                R[i - middle] = inArray[i];

            L = Sort(L, comparer);
            R = Sort(R, comparer);

            return Merge(L, R, comparer);
        }

        private static T[] Merge(T[] L, T[] R, IComparer<T> comparer) {
            T[] MergedArray = new T[L.Length + R.Length];
            int k = 0;
            int lIndex = 0;
            int rIndex = 0;

            while(lIndex < L.Length && rIndex < R.Length) {
                if(comparer.Compare(L[lIndex], R[rIndex]) <= 0) {
                    MergedArray[k++] = L[lIndex++];
                }
                else {
                    MergedArray[k++] = R[rIndex++];
                }
            }

            while(lIndex < L.Length) {
                MergedArray[k++] = L[lIndex++];
            }

            while(rIndex < R.Length) {
                MergedArray[k++] = R[rIndex++];
            }

            return MergedArray;
        }
    }
}


