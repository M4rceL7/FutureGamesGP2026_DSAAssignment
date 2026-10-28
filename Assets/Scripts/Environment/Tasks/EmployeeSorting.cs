using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SortEmplooyes Task", menuName = "SortEmplooyes Task")]
    public class EmployeeSorting : Task {

        public override void Execute() {
            IComparer<EmployeeData.Employee> comparer = Comparer<EmployeeData.Employee>.Create((a, b) => a.lastEntranceInEngineRoom.CompareTo(b.lastEntranceInEngineRoom));

            Utility.MergeSort<EmployeeData.Employee>.Sort(EmployeeArray.Instance.savedEmployees, comparer);
        }
    }
}
