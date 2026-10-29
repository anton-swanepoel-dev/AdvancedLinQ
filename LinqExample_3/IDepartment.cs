namespace LinqExamples_3
{
    public interface IDepartment
    {
        IEnumerable<Employee> Employees { get; set; }
        int Id { get; set; }
        string LongName { get; set; }
        string ShortName { get; set; }
    }
}