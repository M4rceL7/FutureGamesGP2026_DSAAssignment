using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SortEmplooyes Task", menuName = "SortEmplooyes Task")]
    public class EmployeeSorting : Task {

        [System.Serializable]
        public enum SortType {
            MergeSort,
            QuickSort
        }

        public SortType sortType;
        public bool showSortedArray = false;

        public override void Execute() {
            if(SortingUsed.dataStructureUsed == WhereToSave.HashMap)
                return;

            IComparer<EmployeeData.Employee> comparer = Comparer<EmployeeData.Employee>.Create((a, b) => {

                if(a == null && b == null) return 0;
                if(a == null) return 1;
                if(b == null) return -1;

                return a.LastEntranceInEngineRoom.CompareTo(b.LastEntranceInEngineRoom);
            });

            switch(sortType) {
                case SortType.MergeSort:
                    EmployeeArray.Instance.savedEmployeesBS = Utility.MergeSort<EmployeeData.Employee>.Sort(EmployeeArray.Instance.savedEmployeesBS, comparer);
                    if(showSortedArray) {
                        foreach(var employee in EmployeeArray.Instance.savedEmployeesBS) {
                            //Debug.Log($"Name: {employee.Name}");
                            //Debug.Log($"ID: {employee.EmployeeId}");
                            //Debug.Log($"Has Clearance: {employee.HasEngineRoomClearance}");
                            //Debug.Log($"Last Entrance: {employee.LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                            //Debug.Log($"Last Exit: {employee.LastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                        }
                    }
                    break;

                case SortType.QuickSort:
                    Utility.QuickSort.Sort(EmployeeArray.Instance.TempEmployees);
                    EmployeeArray.Instance.savedEmployeesBS = (EmployeeData.Employee[])EmployeeArray.Instance.TempEmployees.Clone();
                    foreach(var employee in EmployeeArray.Instance.savedEmployeesBS) {
                        //Debug.Log($"Name: {employee.Name}");
                        //Debug.Log($"ID: {employee.EmployeeId}");
                        //Debug.Log($"Has Clearance: {employee.HasEngineRoomClearance}");
                        //Debug.Log($"Last Entrance: {employee.LastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                        //Debug.Log($"Last Exit: {employee.LastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                    }
                    break;
            } 
        }
    }
}
