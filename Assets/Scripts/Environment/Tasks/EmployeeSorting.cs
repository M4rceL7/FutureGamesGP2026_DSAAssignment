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

                return a.LastEntranceInEngineRoom.CompareTo(b.LastEntranceInEngineRoom);
            });

            EmployeeArray.Instance.savedEmployees = Utility.MergeSort<EmployeeData.Employee>.Sort(EmployeeArray.Instance.savedEmployees, comparer);

            foreach(var employee in EmployeeArray.Instance.savedEmployees) {
                //Debug.Log($"Name: {employee.Name}");
                //Debug.Log($"ID: {employee.EmployeeId}");
                //Debug.Log($"Has Clearance: {employee.HasEngineRoomClearance}");
                Debug.Log($"Last Entrance: {employee.LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                //Debug.Log($"Last Exit: {employee.LastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
            }
        }
    }
}
