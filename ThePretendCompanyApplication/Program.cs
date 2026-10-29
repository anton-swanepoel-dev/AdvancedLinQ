using System;
using TCPData;
using System.Collections.Generic;
using TCPExtensions;
using System.Linq;

namespace ThePretendCompanyApplication
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Employee> employeeList = Data.GetEmployees();

            var filteredEmployees = employeeList.Where(emp => emp.AnnualSalary < 50000);

            //var filteredEmployees = employeeList.Filter(emp => emp.FirstName == "Bob");


            //foreach (var employee in filteredEmployees)
            //{
            //    Console.WriteLine($"First Name: {employee.FirstName}");
            //    Console.WriteLine($"Last Name: {employee.LastName}");
            //    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            //    Console.WriteLine($"Manager: {employee.IsManager}");
            //    Console.WriteLine();
            //}

            //filteredEmployees.ForEach(employee =>
            //{
            //    Console.WriteLine($"First Name: {employee.FirstName}");
            //    Console.WriteLine($"Last Name: {employee.LastName}");
            //    Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
            //    Console.WriteLine($"Manager: {employee.IsManager}");
            //    Console.WriteLine();
            //}
            //);

            List<Department> departmentList = Data.GetDepartments();

            //var filteredDepartments = departmentList.Where(dep => dep.Id > 1).ToList();
            var filteredDepartments = departmentList.Where(dep => dep.ShortName == "TE" || dep.ShortName == "HR").ToList();


            //filteredDepartments.ForEach(dep => Console.WriteLine($"Department Id: {dep.Id}\nShortName: {dep.ShortName}\nLongName: {dep.LongName}\n"));

            var resultList = (from emp in employeeList
                             join
                             dep in departmentList on emp.DepartmentId equals dep.Id
                             select new
                             {
                                 emp.FirstName,
                                 emp.LastName,
                                 dep.LongName

                             }).ToList();

            var resultList2 = (employeeList.Join(departmentList, em => em.DepartmentId, dep => dep.Id, (em, dep) => new
            {
                FirstName = em.FirstName,
                LastName = em.LastName,
                LongName = dep.LongName,
                AnnualSalary = em.AnnualSalary,
                IsManager = em.IsManager,
                Department = dep.LongName

            }
                )).ToList();

            resultList2.ForEach(item => Console.WriteLine($"Name: {item.FirstName}, Last Name: {item.LastName}, Department: {item.LongName}"));



            resultList2.ForEach(employee =>
            {
                Console.WriteLine($"First Name: {employee.FirstName}");
                Console.WriteLine($"Last Name: {employee.LastName}");
                Console.WriteLine($"Annual Salary: {employee.AnnualSalary}");
                Console.WriteLine($"Manager: {employee.IsManager}");
                Console.WriteLine($"Department: {employee.Department}");
                Console.WriteLine();
            }
            );

            var highestSalary = employeeList.Max(emp => emp.AnnualSalary);
            var lowestSalary = employeeList.Min(emp => emp.AnnualSalary);
            var averageSalary = employeeList.Average(emp => emp.AnnualSalary);

            Console.WriteLine($"The Max Salary is {highestSalary}, the Min Salary is {lowestSalary}, the Avarage Salary is {averageSalary}");


            Console.ReadKey();
        }
    }
}
