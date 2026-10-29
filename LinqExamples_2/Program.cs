using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LINQExamples_2
{
    class Program
    {
        static void Main()
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            //var employeeByDepartment = employeeList.Join(departmentList, em => em.DepartmentId, de => de.Id,
            //    (em, de) => new
            //    {
            //        em.Id,
            //        em.FirstName,
            //        em.LastName,
            //        em.AnnualSalary,
            //        em.DepartmentId,
            //        DepartmentName = de.LongName
            //    }).OrderBy(o => o.DepartmentId).ThenByDescending(o => o.AnnualSalary);

            //foreach (var employee in employeeByDepartment)
            //{
            //    Console.WriteLine($"Id: {employee.Id,-5} first Name: {employee.FirstName,-10} Last Name: {employee.LastName,-10} Annual Salay: {employee.AnnualSalary,10}\tDepartment Name: {employee.DepartmentName}");
            //}

            //Console.WriteLine();


            //var employeeByDepartment2 = from em in employeeList
            //                            join de in departmentList
            //                            on em.DepartmentId equals de.Id
            //                            orderby em.DepartmentId, em.AnnualSalary
            //                            select new
            //                            {
            //                                em.Id,
            //                                em.FirstName,
            //                                em.LastName,
            //                                em.AnnualSalary,
            //                                em.IsManager,
            //                                de.LongName
            //                            };

            //foreach (var employee in employeeByDepartment2)
            //{
            //    Console.WriteLine($"Id: {employee.Id,-5} first Name: {employee.FirstName,-10} Last Name: {employee.LastName,-10} Annual Salay: {employee.AnnualSalary,10}\tDepartment Name: {employee.LongName}");

            //}

            //var groupByDepartMent = from em in employeeList
            //                        join de in departmentList on
            //                        em.DepartmentId equals de.Id
            //                        orderby em.FirstName
            //                        group new
            //                        {
            //                            em.Id,
            //                            em.FirstName,
            //                            em.LastName,
            //                            em.AnnualSalary,
            //                            em.DepartmentId,
            //                            DepartmentName = de.LongName
            //                        }
            //                        by de.LongName into groupedByDepartment
            //                        select groupedByDepartment;

            //foreach (var group in groupByDepartMent)
            //{
            //    Console.WriteLine($"Group: {group.Key,-15}");

            //    foreach (var person in group)
            //    {
            //        Console.WriteLine($"Name: {person.FirstName,-15} LastName: {person.LastName, -20}");
            //    }
            //}

            //Console.WriteLine();

            //var groupByDepart = employeeList.Join(departmentList, em => em.DepartmentId, de => de.Id, (em, de) => new
            //{
            //    em.Id,
            //    em.FirstName,
            //    em.LastName,
            //    em.AnnualSalary,
            //    em.DepartmentId,
            //    DepartmentName = de.LongName
            //}).GroupBy(de => de.DepartmentName);

            //foreach (var group in groupByDepart)
            //{
            //    Console.WriteLine($"Key: {group.Key}");

            //    foreach (var person in group)
            //    {
            //        Console.WriteLine($"Name: {person.FirstName,-15} Last Name: {person.LastName,-15}");
            //    }
            //}



            //var lookUp = employeeList.OrderBy(em => em.DepartmentId).ToLookup(em => em.DepartmentId);

            //foreach (var employee in lookUp)
            //{
            //    Console.WriteLine($"Key: {employee.Key}");

            //    foreach (var person in employee)
            //    {
            //        Console.WriteLine($"Name: {person.FirstName, -15} Last Name: {person.LastName, -20}");
            //    }
            //}

            //var annualSalryCompare = 40000;

            //bool isTrue = employeeList.All(em => em.AnnualSalary > annualSalryCompare);

            //Console.WriteLine(isTrue ? $"Everyone is lucky enough to make over {annualSalryCompare}" : $"Not all people is lucky enough to make over {annualSalryCompare}");

            //bool isAny = employeeList.Any(em => em.AnnualSalary > annualSalryCompare);



            //Console.WriteLine(isAny ? $"At least one person makes more than {annualSalryCompare}": $"no one makes more than {annualSalryCompare}");

            //var employee = new Employee
            //{
            //    Id = 3,
            //    FirstName = "Douglas",
            //    LastName = "Roberts",
            //    AnnualSalary = 40000.2m,
            //    IsManager = false,
            //    DepartmentId = 1
            //};

            //var constainsEmployee = employeeList.Contains(employee, new EmployeeComparer());

            //Console.WriteLine(constainsEmployee);

            //Console.WriteLine(constainsEmployee ? "Yeh the dude is there" : "Nope, he is on lunch");


            //ArrayList mixedCollection = Data.GetHeterogeneousDataCollection();

            //var stringResult = from s in mixedCollection.OfType<string>()
            //                   select s;

            //var intResult = from i in mixedCollection.OfType<int>()
            //                   select i;

            //var employeeResult = from em in mixedCollection.OfType<Employee>()
            //                select em;

            //var departmentResult = from de in mixedCollection.OfType<Department>()
            //                     select de;

            //foreach (var item in departmentResult)
            //{
            //    Console.WriteLine($"the item is a department named {item.LongName}");
            //}

            //Employee employeeAt = employeeList.ElementAtOrDefault(2);

            //Console.WriteLine(employeeAt !=  null ? $"Name: {employeeAt.FirstName} found" : "No record found");

            //Employee? employee = employeeList.FirstOrDefault((em => em.FirstName == "Douglqas" && em.IsManager == true));

            Employee? employee = employeeList.SingleOrDefault(em => em.Id == 1);


            Console.WriteLine(employee !=  null ? $"Name: {employee.LastName}" : "No record found");

            Console.ReadKey();
        }


    }



}