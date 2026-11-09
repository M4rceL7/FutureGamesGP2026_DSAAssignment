using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {
    public class HashMap {
        public const uint OffsetBasis32 = 2166136261;
        public const uint Prime32 = 16777619;
        public const ulong OffsetBasis64 = 14695981039346656037;
        public const ulong Prime64 = 1099511628211;

        public static List<EmployeeData.Employee>[] savingToHashMap(EmployeeData.Employee[] inArray) {
            if(inArray == null)
                throw new ArgumentNullException(nameof(inArray));

            int hashMapSize = getNextPrime((int)Math.Ceiling(inArray.Length / 0.8));

            List<EmployeeData.Employee>[] hashMap = new List<EmployeeData.Employee>[hashMapSize];

            for(int i = 0; i < hashMap.Length; i++) {
                hashMap[i] = new List<EmployeeData.Employee>();
            }

            for(int i = 0; i < inArray.Length; i++) {
                DateTime date = inArray[i].LastEntranceInEngineRoom.Date;

                //int hash = computeHashModulo(date.GetHashCode(), hashMap.Length);
                int hash = (int)(computeHashPrime(date) % (uint)hashMap.Length);

                hashMap[hash].Add(inArray[i]);
            }

            return hashMap;
        }

        //Hash Functions ------------------------------------------------------------------------------------------------------------------------------------
        private static int computeHashModulo(int valueToHash, int hashMapLength) {
            if(hashMapLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(hashMapLength));

            return (int)((uint)valueToHash % (uint)hashMapLength);
        }

        private static uint computeHashPrime(DateTime valueToHash) {
            Span<byte> bytes = stackalloc byte[sizeof(long)];

            BitConverter.TryWriteBytes(bytes, valueToHash.Ticks);

            uint hash = OffsetBasis32;
            foreach (byte b in bytes) {
                hash ^= b;
                hash = unchecked(hash * Prime32);
            }
            return hash;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------------
        public static List<EmployeeData.Employee> get(List<EmployeeData.Employee>[] inHash, DateTime value) {
            if(inHash == null || inHash.Length <= 0)
                throw new ArgumentNullException(nameof(inHash));

            //int hash = computeHashModulo(value.Date.GetHashCode(), inHash.Length);
            int hash = (int)(computeHashPrime(value) % (uint)inHash.Length);

            return inHash[hash];
        }

        //public static List<EmployeeData.Employee> get(List<EmployeeData.Employee>[] inHash, DateTime start, DateTime end) {

        //}

        private static int getNextPrime(int number) {
            number = Math.Max(number, 2);

            while(true) {
                bool isPrime = true;

                for(int i = 2; i <= number / i; i++) {
                    if(number % i == 0) {
                        isPrime = false;
                        break;
                    }
                }

                if(isPrime)
                    return number;

                number++;
            }
        }
    }
}
