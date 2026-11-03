using UnityEngine;
using Newtonsoft.Json;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SaveEmplooyes Task", menuName = "SaveEmplooyes Task")]
    public class SaveEmplooyes : Task{

        public WhereToSave saveOptions;

        public override void Execute() {

            SortingUsed.dataStructureUsed = saveOptions;

            switch(saveOptions) {
                case WhereToSave.Array:
                    Debug.Log("Execute Array");
                    EmployeeArray.Instance.savedEmployeesBS = (EmployeeData.Employee[])EmployeeArray.Instance.TempEmployees.Clone();
                    break;

                    case WhereToSave.HashMap:
                    EmployeeArray.Instance.savedEmployeesHM = Utility.HashMap.savingToHashMap(EmployeeArray.Instance.TempEmployees);
                    Debug.Log("Execute HashMap");
                    break;
            }
            
        }
    }
}
