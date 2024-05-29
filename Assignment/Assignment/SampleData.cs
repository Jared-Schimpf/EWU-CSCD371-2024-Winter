using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Assignment
{
    public class SampleData : ISampleData
    {

        public SampleData(){
            CsvRows = File.ReadAllLines("People.csv").Skip(1);
        }
        // 1.
        public IEnumerable<string> CsvRows{get; set;}//making set public for sake of testing

        // 2.
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => CsvRows.Select(row => row.Split(",")[6]).Distinct().OrderBy(state => state);

        // 3.
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => StateAggregationLogic(GetUniqueSortedListOfStatesGivenCsvRows()); 
        
        
        //impl to consider, will perform worse on larger implementations, 
        // { 
        //     IEnumerable<string> states = GetUniqueSortedListOfStatesGivenCsvRows().ToArray();
        //     return string.Join(",", states);            
        // }

        //bad implementation using aggregation
        // => GetUniqueSortedListOfStatesGivenCsvRows().Aggregate(  
        //     string.Empty,
        //     (output,next) => String.IsNullOrEmpty(output)
        //         ? next
        //         : $"{output}, {next}"
        //     );


        // 4.
        public IEnumerable<IPerson> People => CsvRows.Select(
                row =>{
                     string[] columns = row.Split(",");
                     return new Person(
                        columns[1], columns[2],
                        new Address(
                            columns[4], columns[5], columns[6], columns[7]
                        ), columns[3]
                     );
                }

                ).OrderBy(person => person.Address.State)
                    .ThenBy(person => person.Address.City)
                        .ThenBy(person => person.Address.Zip);

        // 5.
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
            => People.Where(person => filter(person.EmailAddress))
                .Select(person => (person.FirstName, person.LastName)
            );

        // 6.
        public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
            => StateAggregationLogic(
                people.Select(person => person.Address.State).Distinct().OrderBy(state => state)
            );

        private string StateAggregationLogic(IEnumerable<string> States)  //seperated out logic for aggregating a collection of states since it is reused
            => States.Aggregate(
                new StringBuilder(),
                (output,next) => output.Length==0 
                    ? output.Append(next)
                    : output.Append($", {next}"),
                output =>output.ToString()
            );
    }
}
