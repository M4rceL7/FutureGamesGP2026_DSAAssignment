using System;
using UnityEngine;
using Newtonsoft.Json;

//[CreateAssetMenu(fileName = "Employee Data", menuName = "Employee Data")]
public class EmployeeData{

    [System.Serializable]
    public class Employee {
        public string Name;
        public int EmployeeId;
        public bool HasEngineRoomClearance;
        public DateTime LastEntranceInEngineRoom;
        public DateTime LastExitFromEngineRoom;
    }

    public Employee[] employees;
}

