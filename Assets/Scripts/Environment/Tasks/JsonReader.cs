using System;
using UnityEngine;
using Newtonsoft.Json;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "JsonReader Task", menuName = "JsonReader Task")]
    public class JsonReader : Task {
        [SerializeField] private TextAsset jsonFile;

        public override void Execute() {
            EmployeeData data = JsonConvert.DeserializeObject<EmployeeData>(jsonFile.text);

            EmployeeArray.Instance.TempEmployees = data.employees;
        }
    }
}

