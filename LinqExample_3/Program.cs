using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqExamples_3;

class Program
{
    static void Main()
    {
        List<Employee> employeeList = Data.GetEmployees();
        List<Department> departmentList = Data.GetDepartments(employeeList);

        //Equality operator
        //SequenceEquels

        //var integerList1 = new List<int> { 1, 2, 3, 4, 5, 6 };
        //var integerList2 = new List<int> { 1, 2, 3, 4, 5, 6 };
        //var boolSequenceSelect = integerList1.SequenceEqual(integerList2);

        //Console.WriteLine(boolSequenceSelect);

        //var employeeListCompare = Data.GetEmployees();
        //bool employeeListSame = employeeList.SequenceEqual(employeeListCompare, new EmployeeComparer());

        //Console.WriteLine(employeeListSame);

        //Concat operator
        //List<int> integerList1 = new List<int> { 1, 2, 3, 4 };
        //List<int> integerList2 = new List<int> { 5, 6, 7, 8, 9, 10 };

        //IEnumerable<int> integerConcat = integerList1.Concat(integerList2);

        //foreach(var value in integerConcat)
        //{
        //    Console.WriteLine(value);
        //}

        //List<Employee> employeeListConcat = new List<Employee> { new Employee { Id = 6, FirstName = "Debbie", LastName = "Townsend", AnnualSalary = 80000, IsManager = false, DepartmentId = 1 } };

        //IEnumerable<Employee> employeeListCombined = employeeList.Concat(employeeListConcat);

        //foreach (var person in employeeListCombined)
        //{
        //    Console.WriteLine($"Name: {person.FirstName,-15} Last Name: {person.LastName,-20}");
        //}

        //Aggregate operators
        //decimal totalAnnualSalary = employeeList.Aggregate<Employee, decimal >(0, (totalAnnualSalary, e) =>
        //{
        //    var bonus = (e.IsManager == true) ? 0.4m : 0.2m;
        //    totalAnnualSalary = (e.AnnualSalary + (e.AnnualSalary * bonus)) + totalAnnualSalary;
        //    return totalAnnualSalary;
        //});

        //Console.WriteLine(totalAnnualSalary);

        //string data = employeeList.Aggregate<Employee, string, string>("Employee Annual Salary (including bonus): ",
        //    (s, e) =>
        //    {
        //        var bonus = (e.IsManager == true) ? 0.4m : 0.2m;
        //        s += $"\n{e.FirstName} {e.LastName} - {e.AnnualSalary + (e.AnnualSalary * bonus)}, ";
        //        return s;
        //    }, s => s.Substring(0, s.Length - 2)
        //    );

        //Console.WriteLine($"{data}");

        //average aggregate

        //decimal average = employeeList.Where(e => e.DepartmentId == 3).Average(e => e.AnnualSalary);

        //Console.WriteLine($"Average annual salary {average}");

        //Console.WriteLine($"Total number of employees {employeeList.Count()}");

        //Console.WriteLine($"Total number of employees in tecnology department {employeeList.Count(e => e.DepartmentId == 3)}");

        //Console.WriteLine($"The sum total of salaries is {employeeList.Sum(e => e.AnnualSalary)}");

        //Console.WriteLine($"The max salary is {employeeList.Max(e => e.AnnualSalary)}");

        //Console.WriteLine($"The max salary in tchnology is {employeeList.Where(e => e.DepartmentId == 3).Max(e => e.AnnualSalary)}");

        //Console.WriteLine($"The min salary in tchnology is {employeeList.Where(e => e.DepartmentId == 3).Min(e => e.AnnualSalary)}");

        //generation operators
        //List<int> intList = new List<int>();
        //var newlist = intList.DefaultIfEmpty();

        //Console.WriteLine(newlist.ElementAt(0));

        //List<Employee> employees = new List<Employee>();

        //var newList = employees.DefaultIfEmpty(new Employee { Id = 0});

        //foreach(var item in newList)
        //{
        //    Console.WriteLine(item.Id == 0 ? "The list is empty" : $"{item.Id}");
        //}

        //empty method
        //List<Employee> emptyEmployeeList = Enumerable.Empty<Employee>().ToList();
        //emptyEmployeeList.Add(new Employee { Id = 7, FirstName = "John", LastName = "Scott", AnnualSalary = 300000, DepartmentId = 3, IsManager = true });

        //emptyEmployeeList.ForEach(e => Console.WriteLine($"{e.FirstName}"));

        //range values
        //var intCollection = Enumerable.Range(25, 20);
        //foreach (var item in intCollection)
        //{
        //    Console.WriteLine(item);
        //}

        //repeat
        //var intRepeatCollection = Enumerable.Repeat(25, 20);

        //foreach(var item in intRepeatCollection)
        //{
        //    Console.WriteLine(item);
        //}

        //set operators

        //List<int> intList = new List<int> { 1, 2, 1, 4, 6, 2, 6, 7, 8, 7, 7, 7};
        //List<int> intList2 = new List<int> { 1, 7 };


        ////var distinctList = intList.Distinct().ToList();
        //var exceptList = intList.Except(intList2).ToList();

        //exceptList.ForEach(item => Console.WriteLine(item ));

        List<Employee> employees = new List<Employee> { new Employee { Id = 1,
                FirstName = "Bobby",
                LastName = "Jones",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 2 } ,
            new Employee{
                Id = 2,
                FirstName = "Sam",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 3} ,
            new Employee{
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 3}  };

        //List <Employee> distinctEmployees = employeeList.Except(employees, new EmployeeComparer()).ToList();


        //distinctEmployees.ForEach(item => Console.WriteLine(item.FirstName));

        //var employeeInterect = employeeList.Intersect(employees, new EmployeeComparer()).ToList();

        //var employeeUnion = employeeList.Union(employees, new EmployeeComparer()).ToList();

        //employeeUnion.ForEach(item => Console.WriteLine($"First Name: {item.FirstName, -15} Last Name: {item.LastName, -20}"));

        //partitionining operators. skip, skip while and takewhile

        //var employeeSkip = employeeList.Skip(2).ToList();

        //var employeeSkipWhile = employeeList.SkipWhile(emp => emp.AnnualSalary > 50000).ToList();

        //employeeSkipWhile.ForEach(item => Console.WriteLine($"First Name: {item.FirstName, -15} Last Name: {item.LastName, -20} Annual Salary: {item.AnnualSalary, 10}"));

        //var employeeTake = employeeList.Take(3).ToList();
        //employeeTake.ForEach(item => Console.WriteLine($"First Name: {item.FirstName, -15} Last Name: {item.LastName, -20} Annual Salary: {item.AnnualSalary, 10}"));

        //var employeeTakeWhile = employeeList.TakeWhile(emp => emp.AnnualSalary > 40000).ToList();
        //employeeTakeWhile.ForEach(item => Console.WriteLine($"First Name: {item.FirstName, -15} Last Name: {item.LastName, -20} Annual Salary: {item.AnnualSalary, 10}"));

        //Dictionary<string, Employee> employeeDictionay = employeeList.TakeWhile(emp => emp.AnnualSalary > 40000).ToDictionary<Employee, string>(em => em.FirstName);

        //foreach (var value in employeeDictionay)
        //{
        //    Console.WriteLine($"Key: {value.Key} Name: {employeeDictionay[value.Key].FirstName, -15} Last Name {employeeDictionay[value.Key].LastName, -20}");
        //}

        //Employee[] emploueeArray = employeeList.TakeWhile(emp => emp.AnnualSalary > 40000).ToArray();

        //var emp = from employee in employeeList
        //          let Initials = employee.FirstName.Substring(0, 1).ToUpper() + employee.LastName.Substring(0, 1).ToUpper()
        //          let AnnualSalryBonus = (employee.IsManager ? (employee.AnnualSalary + (employee.AnnualSalary * 0.04m)) : (employee.AnnualSalary + (employee.AnnualSalary * 0.02m)))
        //          where Initials == "BJ" || Initials == "JS" || Initials == "SJ" && AnnualSalryBonus > 50000
        //          select new
        //          {
        //              Initials = Initials,
        //              FirstName = employee.FirstName,
        //              LastName = employee.LastName,
        //              AnnualSalary = AnnualSalryBonus
        //          };

        //foreach (var item in emp)
        //{
        //    Console.WriteLine($"Initials: {item.Initials, -4} First Name: {item.FirstName, -15} Last Name: {item.LastName, -20} Annual Salary: {item.AnnualSalary}");
        //}

        //var result = from emp in employeeList
        //             where emp.AnnualSalary > 50000
        //             select emp
        //             into HighEarners
        //             where HighEarners.IsManager == true
        //             select HighEarners;

        //foreach (var item in result)
        //{
        //    Console.WriteLine($"First Name: {item.FirstName, -15} Last Name: {item.LastName, -20} Annual Salary: {item.AnnualSalary}");

        //}


        //var results = departmentList.Select(em => ( em.Employees, em.LongName));

        ////employeeList[0].DepartmentId = 1;

        //foreach (var dept in results)
        //{
        //    Console.WriteLine($"Department: {dept.LongName}");
        //    foreach(var item in dept.Employees)
        //    {
        //        Console.WriteLine($"First Name: {item.FirstName, -15} Last Name: {item.LastName, -20} Annual Salary: {item.AnnualSalary}");

        //    }
        //    Console.WriteLine();
        //}

        var results = departmentList.SelectMany(em => em.Employees);

        foreach (var item in results)
        {
                Console.WriteLine($"First Name: {item.FirstName,-15} Last Name: {item.LastName,-20} Annual Salary: {item.AnnualSalary}");

        }

        Console.ReadKey();
    }
}