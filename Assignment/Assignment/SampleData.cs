using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment
{
    public class SampleData : ISampleData
    {
        // Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
        private static class Column
        {
            public static int ID => 0;
            public static int FirstName => 1;
            public static int LastName => 2;
            public static int EmailAddress => 3;
            public static int StreetAddress => 4;
            public static int City => 5;
            public static int State => 6;
            public static int Zip => 7;
        }
        public SampleData()
        {
            CsvRows = File.ReadAllLines("People.csv").Skip(1);
        }

        // 1.
        public IEnumerable<string> CsvRows
        {
            get; private set;
        }

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
            => CsvRows.Select(item => item.Split(',')[Column.State]).Distinct().OrderBy(item => item);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => GetUniqueSortedListOfStatesGivenCsvRows().Aggregate(new StringBuilder(), 
                (current, item) => current.Length==0?current.Append(item):current.Append(", ").Append(item), current=>current.ToString());

        // 4.
        public IEnumerable<IPerson> People => 
            CsvRows.Select(item =>
            {
                string[] columns = item.Split(",");
                return new Person(
                    columns[Column.FirstName],
                    columns[Column.LastName],
                    new Address(
                        columns[Column.StreetAddress],
                        columns[Column.City],
                        columns[Column.State],
                        columns[Column.Zip]),
                    columns[Column.EmailAddress]);
            })
            .OrderBy(item=>item.Address.State)
                .ThenBy(item=>item.Address.City)
                .ThenBy(item=>item.Address.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) =>
            People.Where(item => filter(item?.EmailAddress!))
                .Select(item => (item.FirstName, item.LastName));

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
