using UnityEngine;

public class EmployeeArray
{
    public static EmployeeArray Instance { get; private set; }

    public EmployeeData.Employee[] TempEmployees { get; set; }

    public EmployeeData.Employee[] savedEmployees { get; set; }
}
