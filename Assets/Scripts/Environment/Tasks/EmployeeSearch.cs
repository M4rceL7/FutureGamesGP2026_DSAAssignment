using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using static EmployeeData;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SearchEmplooyes Task", menuName = "SearchEmplooyes Task")]
    public class EmployeeSearch : Task {
        [System.Serializable]
        public class SearchDate {
            public int year = 1;
            public int month = 1;
            public int day = 1;
        }

        [SerializeField] private SearchDate startDate = new();
        [SerializeField] private SearchDate endDate = new();
        List<EmployeeData.Employee> allInRange = new List<EmployeeData.Employee>();



        public override void Execute() {
            DateTime start = new DateTime(startDate.year, startDate.month, startDate.day);
            DateTime end = new(endDate.year, endDate.month, endDate.day);
            
            //int index = Utility.Benchmark.RunBenchmark(() =>
            //    Utility.BinarySearch.binarySearch(EmployeeArray.Instance.savedEmployees, start,
            //        employee => employee.LastEntranceInEngineRoom.Date));

            //if(index == -1) {
            //    Debug.Log("Could not find an employee with current search criteria");
            //}
            //else {
            //    Debug.Log("Employee found:");
            //    Debug.Log($"Name: {EmployeeArray.Instance.savedEmployees[index].Name}");
            //    Debug.Log($"ID: {EmployeeArray.Instance.savedEmployees[index].EmployeeId}");
            //    Debug.Log($"Has Clearance: {EmployeeArray.Instance.savedEmployees[index].HasEngineRoomClearance}");
            //    Debug.Log($"Last Entrance: {EmployeeArray.Instance.savedEmployees[index].LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
            //    Debug.Log($"Last Exit: {EmployeeArray.Instance.savedEmployees[index].LastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
            //}

            allInRange = Utility.Benchmark.RunBenchmark(() =>
                Utility.BinarySearch.binarySearch(EmployeeArray.Instance.savedEmployees, start, end,
                    employee => employee.LastEntranceInEngineRoom.Date));

            foreach( Employee emp in allInRange) {
                Debug.Log("Employee found:");
                Debug.Log($"Name: {emp.Name}");
                Debug.Log($"Last Entrance: {emp.LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
            }
        }
    }
}

