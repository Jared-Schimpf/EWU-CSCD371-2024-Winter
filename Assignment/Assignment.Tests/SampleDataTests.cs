using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace Assignment.Tests;

[TestClass]
public class SampleDataTests
{
    ISampleData SampleData { get; } = new SampleData();
    IEnumerable<string> Data => SampleData.CsvRows;

    [TestMethod]
    public void CsvRows_Instantiation_Successful(){
        Assert.IsTrue(Data.Contains("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577"));
        Assert.IsTrue(Data.Contains("40,Selia,Bowe,sbowe13@360.cn,42 Lerdahl Plaza,New Orleans,LA,13260"));
        Assert.IsTrue(Data.Contains("23,Jermaine,Danelutti,jdaneluttim@jimdo.com,7 Onsgard Lane,Frederick,MD,56551"));
    }

    [TestMethod]
    public void CsvRows_NoContains_Header(){
         Assert.IsTrue(!Data.Contains("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip"));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IncludesHardcoded()
    {
        SampleData testData = new();
        testData.CsvRows = ["e,e,e,e,e,e,MT,e", "r,r,r,r,r,r,LA,r", "q,q,q,q,q,q,WA,q"];
        CollectionAssert.AreEqual((List<string>)["LA","MT","WA"], testData.GetUniqueSortedListOfStatesGivenCsvRows().ToList());  
    }


    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IsSorted(){
        ConditionCheckingEnumerator((prev, curr) =>Assert.IsTrue(prev.CompareTo(curr) <= 0), SampleData.GetUniqueSortedListOfStatesGivenCsvRows());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IsUnique(){
        ConditionCheckingEnumerator((prev, curr) =>Assert.IsTrue(prev != curr), SampleData.GetUniqueSortedListOfStatesGivenCsvRows());
    }


    void ConditionCheckingEnumerator<T>(Action <T, T> assertCondition, IEnumerable<T> collection)where T : IComparable<T>{
        IEnumerator<T> states = collection.GetEnumerator();
        if(!states.MoveNext()) return;

        T prev = states.Current;
    

        while(states.MoveNext()){
            T curr = states.Current;
            assertCondition(prev, curr);
            prev = states.Current; 
            //this only works for testing uniqueness if the list is properly sorted because otherwise items that are equivalent may not be adjacent
        }
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_NoExtraComma()
    {
        string expected = string.Join(", ", SampleData.GetUniqueSortedListOfStatesGivenCsvRows());

        Assert.AreEqual(expected, SampleData.GetAggregateSortedListOfStatesUsingCsvRows());
    }

    [TestMethod]
    public void People_Address_NotNull()
    {
        IEnumerable<IPerson> people = SampleData.People;
        Assert.IsTrue(people.All(item => item.Address is not null));
    }


    [TestMethod]
    public void People_SortedByStateCityandZip() //had to implement CompareTo in address
    {
        IEnumerable<IPerson> people = SampleData.People;
        ConditionCheckingEnumerator((prev, curr) =>Assert.IsTrue(prev.CompareTo(curr) <= 0), people.Select(person => person.Address));
    }

     [TestMethod]
    public void FilterByEmailAddress_Filters()
    {  
        IEnumerable<(string FirstName, string LastName)> expected = SampleData.People.Where(
            person => person.EmailAddress.ToLower().EndsWith("edu")).Select(person => (person.FirstName, person.LastName));


        IEnumerable<(string FirstName, string LastName)> actual = 
            SampleData.FilterByEmailAddress(email => email.ToLower().EndsWith("edu"));

        CollectionAssert.AreEqual(expected.ToList(), actual.ToList());
    }




}
