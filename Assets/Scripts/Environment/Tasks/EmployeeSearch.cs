using System;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SearchEmplooyes Task", menuName = "SearchEmplooyes Task")]
    public class EmployeeSearch : Task {

        [System.Serializable]
        public class SearchDate {
            public int year = 1;
            public int month = 1;
            public int day = 1;
            public int hour = 0;
            public int minute = 0;
            public int second = 0;
        }

        private WhereToSave searchIn;

        [SerializeField] private SearchDate startDate = new();
        [SerializeField] private SearchDate endDate = new();
        List<EmployeeData.Employee> allInRange = new List<EmployeeData.Employee>();



        public override void Execute() {
            searchIn = SortingUsed.dataStructureUsed;

            DateTime start = new DateTime(startDate.year, startDate.month, startDate.day, startDate.hour, startDate.minute, startDate.second);
            DateTime end = new DateTime(endDate.year, endDate.month, endDate.day, endDate.hour, endDate.minute, endDate.second);

            switch(searchIn) {
                case WhereToSave.Array:
                    Debug.Log("Array Used");
                    allInRange = Utility.Benchmark.RunBenchmark(() =>
                        Utility.BinarySearch.binarySearch(EmployeeArray.Instance.savedEmployeesBS, start, end,
                            employee => employee.LastEntranceInEngineRoom));

                    foreach(EmployeeData.Employee emp in allInRange) {
                        Debug.Log("Employee found:");
                        Debug.Log($"Name: {emp.Name}");
                        Debug.Log($"Last Entrance: {emp.LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                        Debug.Log($"Last Exit: {emp.LastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                    }
                    break;

                case WhereToSave.HashMap:
                    Debug.Log("HashMap Used");
                    List<EmployeeData.Employee> targetsInRange = Utility.Benchmark.RunBenchmark(() => Utility.HashMap.get(EmployeeArray.Instance.savedEmployeesHM, start, end)); 
                    foreach(EmployeeData.Employee emp in targetsInRange) {
                        Debug.Log("Employee found:");
                        Debug.Log($"Name: {emp.Name}");
                        Debug.Log($"Last Entrance: {emp.LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                        Debug.Log($"Last Exit: {emp.LastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                    }

                    break;
            }
        }
    }
}

