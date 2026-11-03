using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility {
    public class HashMap {

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

                int hash = computeHash(date.GetHashCode(), hashMap.Length);

                hashMap[hash].Add(inArray[i]);
            }

            return hashMap;
        }

        private static int computeHash(int valueToHash, int hashMapLength) {
            if(hashMapLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(hashMapLength));

            return (int)((uint)valueToHash % (uint)hashMapLength);
        }

        public static List<EmployeeData.Employee> get(List<EmployeeData.Employee>[] inHash, DateTime value) {
            if(inHash == null || inHash.Length <= 0)
                throw new ArgumentNullException(nameof(inHash));

            int hash = computeHash(value.Date.GetHashCode(), inHash.Length);

            return inHash[hash];
        }

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
