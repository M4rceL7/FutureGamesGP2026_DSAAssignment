using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Utility {
    public class MergeSort<T> {

        public static T[] Sort(T[] inArray, IComparer<T> comparer) {
            if(inArray == null || inArray.Length == 0) return null;

            T[] L = new T[inArray.Length / 2];
            T[] R = new T[inArray.Length / 2];
            T[] OutArray = new T[inArray.Length];

            while(L.Length != 1 && R.Length != 1) {
                if(L.Length != 1) {
                    for(int i = 0; i < L.Length; i++) {
                        L[i] = inArray[i];
                    }
                    Sort(L, comparer);
                }

                if(R.Length != 1) {
                    for(int i = 0; i < R.Length; i++) {
                        R[i] = inArray[i + R.Length];
                    }
                    Sort(R, comparer);
                }
            }
            OutArray = Merge(L, R, comparer);
            return OutArray;
        }

        private static T[] Merge(T[] L, T[] R, IComparer<T> comparer) {
            T[] MergedArray = new T[L.Length + R.Length];

            if(L.Length == 1 && R.Length == 1) {
                if(comparer.Compare(L[0], R[0]) >= 0) {
                    MergedArray[0] = L[0];
                    MergedArray[1] = R[0];
                }
                else {
                    MergedArray[0] = R[0];
                    MergedArray[1] = L[0];
                }
                return MergedArray;
            }
            else {
                for(int i = 0; i < L.Length; i++) {
                    for(int j = 0; j < R.Length; j++) {

                    }
                }
            }

            return MergedArray;
        }
    }
}


