using System;
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



        public override void Execute() {
            DateTime start = new DateTime(startDate.year, startDate.month, startDate.day);
            DateTime end = new(endDate.year, endDate.month, endDate.day);

            int index = Utility.BinarySearch.binarySearch(EmployeeArray.Instance.savedEmployees, start, employee => employee.LastEntranceInEngineRoom.Date);

            if(index == -1) {
                Debug.Log("Could not find an employee with current search criteria");
            }
            else {
                Debug.Log("Employee found:");
                Debug.Log($"Name: {EmployeeArray.Instance.savedEmployees[index].Name}");
                Debug.Log($"ID: {EmployeeArray.Instance.savedEmployees[index].EmployeeId}");
                Debug.Log($"Has Clearance: {EmployeeArray.Instance.savedEmployees[index].HasEngineRoomClearance}");
                Debug.Log($"Last Entrance: {EmployeeArray.Instance.savedEmployees[index].LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                Debug.Log($"Last Exit: {EmployeeArray.Instance.savedEmployees[index].LastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
            }
        }
    }
}

