using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace LINQExamples_1
{
    class Progeam
    {
        static void Main()
        {
            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departments = Data.GetDepartments();

            //var results = (employeeList.Select(em => new
            //{
            //    FullName = em.FirstName + " " + em.LastName,
            //    em.AnnualSalary,
            //    em.DepartmentId,
            //    em.IsManager
            //})).Where(em => em.AnnualSalary > 50000).ToList();

            //results.ForEach(person => Console.WriteLine($"Name: {person.FullName,-20} Salary: {person.AnnualSalary,10}"));

            //var results2 = from em in employeeList
            //               where em.AnnualSalary > 50000
            //               select new
            //               {
            //                   FullName = em.FirstName + " " + em.LastName,
            //                   em.AnnualSalary,
            //                   em.DepartmentId,
            //                   em.IsManager
            //               };
            employeeList.Add(new Employee { FirstName = "Anton", LastName = "Swanepoel", AnnualSalary = 200000.1m, IsManager = true, DepartmentId = 1, Id = 5 });


            //Console.WriteLine();

            //results2.ToList().ForEach(person => Console.WriteLine($"Name: {person.FullName,-20} Salary: {person.AnnualSalary,10}"));

            //var results3 = from em in employeeList.GetHighSalariedEmployees()
            //               select new
            //               {
            //                   FullName = em.FirstName + " " + em.LastName,
            //                   em.AnnualSalary,
            //                   em.DepartmentId,
            //                   em.IsManager
            //               };



            employeeList.Add(new Employee
            {
                FirstName = "Piet",
                LastName = "Pompies",
                AnnualSalary = 20000.1m,
                IsManager = false,
                DepartmentId = 1,
                Id = 6
            });

            //foreach (var person in results3)
            //{
            //    Console.WriteLine($"Name: {person.FullName}");
            //    Console.WriteLine($"Salary: {person.AnnualSalary}");
            //}

            var joinedResults = from em in employeeList
                                join d in departments on em.DepartmentId equals d.Id
                                select new
                                {
                                    FullName = em.FirstName + " " + em.LastName,
                                    em.AnnualSalary,
                                    em.DepartmentId,
                                    em.IsManager,
                                    d.LongName
                                };

            joinedResults.ToList().ForEach(person => Console.WriteLine($"Name: {person.FullName,-20}" +
                $" Salary: {person.AnnualSalary,10}, " +
                $"Department: {person.LongName}"));

            Console.WriteLine();


            var joineResults2 = employeeList.Join(departments, em => em.DepartmentId, de => de.Id, (em, de) => new
            {
                FullName = em.FirstName + " " + em.LastName,
                em.AnnualSalary,
                em.DepartmentId,
                em.IsManager,
                de.LongName
            });

            joineResults2.ToList().ForEach(person => Console.WriteLine($"Name: {person.FullName,-20}" +
            $" Salary: {person.AnnualSalary,10}, " +
            $"Department: {person.LongName}"));

            Console.WriteLine();


            var results4 = from em in employeeList
                           join de in departments on em.DepartmentId equals de.Id
                           where em.AnnualSalary > 100000
                           select new
                           {
                               FullName = em.FirstName + " " + em.LastName,
                               em.AnnualSalary,
                               em.DepartmentId,
                               em.IsManager,
                               de.LongName
                           };
            results4.ToList().ForEach(person => Console.WriteLine($"Name: {person.FullName,-20}" +
           $" Salary: {person.AnnualSalary,10}, " +
           $"Department: {person.LongName}"));

            var results5 = employeeList.Where(em => em.AnnualSalary > 10000).Join(departments, em => em.DepartmentId, de => de.Id, (emp, dep) => new
            {
                FullName = emp.FirstName + " " + emp.LastName,
                emp.AnnualSalary,
                emp.DepartmentId,
                emp.IsManager,
                dep.LongName
            });

            results5.ToList().ForEach(person => Console.WriteLine($"Name: {person.FullName,-20}" +
      $" Salary: {person.AnnualSalary,10}, " +
      $"Department: {person.LongName}"));

            var results6 = employeeList.Where(em => em.IsManager).OrderByDescending(em => em.DepartmentId).Join(departments, em => em.DepartmentId, de => de.Id, (em, de) => new
            {
                FullName = em.FirstName + " " + em.LastName,
                AnnualSalary = em.AnnualSalary,
                em.DepartmentId,
                em.IsManager,
                de.LongName
            }).GroupBy(de => de.LongName);

            foreach (var group in results6)
            {
                Console.WriteLine($"Department: {group.Key}");
                foreach (var person in group)
                {
                    Console.WriteLine($"Name: {person.FullName,-20}  Department: {person.LongName}");
                }
            }


            var result7 = from em in employeeList
                          where em.AnnualSalary < 100000
                          orderby em.FirstName
                          join de in departments on em.DepartmentId equals de.Id
                          group new
                          {
                              FullName = em.FirstName + " " + em.LastName,
                              AnnualSalary = em.AnnualSalary,
                              em.DepartmentId,
                              em.IsManager,
                              de.LongName
                          }
                          by de.LongName into departmentGroup
                          select departmentGroup;

            var result9 = from em in employeeList
                          where em.AnnualSalary < 100000
                          orderby em.FirstName
                          join de in departments on em.DepartmentId equals de.Id
                          into employeegroup
                          select new
                          {
                              FullName = em.FirstName + " " + em.LastName,
                              AnnualSalary = em.AnnualSalary,
                              em.DepartmentId,
                              em.IsManager,
                              LongName = employeegroup
                          };


            foreach (var group in result9)
            {
                Console.WriteLine($"Department: {group.LongName}");
                    Console.WriteLine($"Name: {group.FullName,-20}  Department: {group.LongName}");
                
            }

            var result8 = departments.GroupJoin(employeeList, de => de.Id, em => em.DepartmentId, (de, em) => new
            {
                de.LongName,
                employee = em
                
            });


            foreach (var group in result8)
            {
                Console.WriteLine($"Department: {group.LongName}");

                foreach(var person in group.employee)
                {
                    Console.WriteLine(value: $"Employee: {person.FirstName}");
                }
            }


            var results10 = from dep in departments
                            join em in employeeList
                            on dep.Id equals em.DepartmentId
                            into employeeGroup
                            select new
                            {
                                employee = employeeGroup,
                                Department = dep.LongName
                            };

            foreach (var department in results10)
            {
                Console.WriteLine($"Department: {department.Department}");
                foreach (var person in department.employee)
                {
                    Console.WriteLine($"Name: {person.FirstName, -15} Salary: {person.AnnualSalary, 10}");
                }
            }


            Console.ReadKey();
        }



    }


    public static class EnumerableCollectionExtentionMethod
    {
        public static IEnumerable<Employee> GetHighSalariedEmployees(this IEnumerable<Employee> records)
        {
            foreach (var employee in records)
            {
                Console.WriteLine($"Accessing exployee: {employee.FirstName} + ' ' + {employee.LastName}");
                if (employee.AnnualSalary > 50000) yield return employee;
            }

        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal AnnualSalary { get; set; }
        public bool IsManager { get; set; }
        public int DepartmentId { get; set; }

    }

    public class Department
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
    }

    public static class Data
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Employee employee = new Employee
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Jones",
                AnnualSalary = 60000.3m,
                IsManager = true,
                DepartmentId = 1
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Jameson",
                AnnualSalary = 80000.1m,
                IsManager = true,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 3,
                FirstName = "Douglas",
                LastName = "Roberts",
                AnnualSalary = 40000.2m,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);
            employee = new Employee
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Stevens",
                AnnualSalary = 30000.2m,
                IsManager = false,
                DepartmentId = 2
            };
            employees.Add(employee);

            return employees;
        }

        public static List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            Department department = new Department
            {
                Id = 1,
                ShortName = "HR",
                LongName = "Human Resources"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 2,
                ShortName = "FN",
                LongName = "Finance"
            };
            departments.Add(department);
            department = new Department
            {
                Id = 3,
                ShortName = "TE",
                LongName = "Technology"
            };
            departments.Add(department);

            return departments;
        }



    }
}