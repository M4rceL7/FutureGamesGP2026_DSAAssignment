using UnityEngine;

public class EmployeeArray
{
    public static EmployeeArray Instance { get; } = new EmployeeArray();

    public EmployeeData.Employee[] TempEmployees { get; set; }

    public EmployeeData.Employee[] savedEmployees { get; set; }

    private EmployeeArray() { }
}
