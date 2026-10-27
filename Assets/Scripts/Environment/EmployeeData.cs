using System;
using UnityEngine;
using Newtonsoft.Json;

//[CreateAssetMenu(fileName = "Employee Data", menuName = "Employee Data")]
public class EmployeeData{

    [System.Serializable]
    public class Employee {
        public string name;
        public int employeeId;
        public bool hasEngineRoomClearance;
        public DateTime lastEntranceInEngineRoom;
        public DateTime lastExitFromEngineRoom;
    }

    public Employee[] employees;
}

