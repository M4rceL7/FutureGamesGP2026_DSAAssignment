using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SortEmplooyes Task", menuName = "SortEmplooyes Task")]
    public class EmployeeSorting : Task {

        public override void Execute() {
            IComparer<EmployeeData.Employee> comparer = Comparer<EmployeeData.Employee>.Create((a, b) => {

                if(a == null && b == null) return 0;
                if(a == null) return 1;
                if(b == null) return -1;

                return a.lastEntranceInEngineRoom.CompareTo(b.lastEntranceInEngineRoom);
            });

            EmployeeArray.Instance.savedEmployees = Utility.MergeSort<EmployeeData.Employee>.Sort(EmployeeArray.Instance.savedEmployees, comparer);

            foreach(var employee in EmployeeArray.Instance.savedEmployees) {
                Debug.Log($"Name: {employee.name}");
                Debug.Log($"ID: {employee.employeeId}");
                Debug.Log($"Has Clearance: {employee.hasEngineRoomClearance}");
                Debug.Log($"Last Entrance: {employee.lastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                Debug.Log($"Last Exit: {employee.lastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
            }
        }
    }
}
