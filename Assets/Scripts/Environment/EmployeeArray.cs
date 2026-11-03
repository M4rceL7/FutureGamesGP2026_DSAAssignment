using System.Collections.Generic;
using UnityEngine;

public class EmployeeArray
{
    public static EmployeeArray Instance { get; } = new EmployeeArray();

    public EmployeeData.Employee[] TempEmployees { get; set; }

    public EmployeeData.Employee[] savedEmployeesBS { get; set; }

    public List<EmployeeData.Employee>[] savedEmployeesHM { get; set; }
}
