using UnityEngine;
using Newtonsoft.Json;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SaveEmplooyes Task", menuName = "SaveEmplooyes Task")]
    public class SaveEmplooyes : Task{
        
        public override void Execute() {
            EmployeeArray.savedEmployees = (EmployeeData.Employee[])EmployeeArray.TempEmployees.Clone();

            foreach(var employee in EmployeeArray.savedEmployees) {
                Debug.Log($"Name: {employee.name}");
                Debug.Log($"ID: {employee.employeeId}");
                Debug.Log($"Has Clearance: {employee.hasEngineRoomClearance}");
                Debug.Log($"Last Entrance: {employee.lastEntranceInEngineRoom:yyyy-MM-ddTHH:mm:ss}");
                Debug.Log($"Last Exit: {employee.lastExitFromEngineRoom:yyyy-MM-ddTHH:mm:ss}");
            }
        }
    }
}
