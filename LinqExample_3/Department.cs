using System;

namespace LinqExamples_3;

public class Department : IDepartment
{
    public int Id { get; set; }
    public string ShortName { get; set; }
    public string LongName { get; set; }

    public IEnumerable<Employee> Employees { get; set; }



}
