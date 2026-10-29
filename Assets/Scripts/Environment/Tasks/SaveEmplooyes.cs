using UnityEngine;
using Newtonsoft.Json;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SaveEmplooyes Task", menuName = "SaveEmplooyes Task")]
    public class SaveEmplooyes : Task{
        
        public override void Execute() {
            EmployeeArray.Instance.savedEmployees = (EmployeeData.Employee[])EmployeeArray.Instance.TempEmployees.Clone();
        }
    }
}
