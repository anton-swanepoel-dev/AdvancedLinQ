using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LINQExamples_2
{

    public static class Extension
    {
        public static List<T> Filter<T>(this List<T> records, Func<T, bool> func)
        {
            List<T> filteredList = new List<T>();

            foreach (T record in records)
            {
                if (func(record))
                {
                    filteredList.Add(record);
                }
            }

            return filteredList;
        }
    }

    public class EmployeeComparer : IEqualityComparer<Employee>
    {
        public bool Equals(Employee? x, Employee? y)
        {
            return (x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName);
        }

        public int GetHashCode([DisallowNull] Employee obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
