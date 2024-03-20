using System;
using System.Collections.Generic;
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
    public void CsvRows_Success()
    {
        Assert.IsTrue(Data.Contains("1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577"));
        Assert.IsTrue(Data.Contains("40,Selia,Bowe,sbowe13@360.cn,42 Lerdahl Plaza,New Orleans,LA,13260"));

    }
    [TestMethod]
    public void CsvRows_FirstRowIsNotHeader_Success()
    {
        Assert.IsTrue(Data.Any(item => !item.Contains("FirstName")));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_IncludesWAAndIL_Success()
    {
        Assert.IsTrue(SampleData.GetUniqueSortedListOfStatesGivenCsvRows().Any(
            item => item.Contains("FL")));
        Assert.IsTrue(SampleData.GetUniqueSortedListOfStatesGivenCsvRows().Any(
            item => item.Contains("MT")));
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_AreSorted_Success()
    {
        AssertListIsSorted<string>(
            SampleData.GetUniqueSortedListOfStatesGivenCsvRows());
    }

    [TestMethod]
    public void GetUniqueSortedListOfStatesGivenCsvRows_AreDistinct_Success()
    {
        AssertNextItem((last, current) => Assert.IsTrue(last != current));
    }

    void AssertNextItem(Action<string, string> assert)
    {
        SampleData data = new();
        IEnumerable<string> items = data.GetUniqueSortedListOfStatesGivenCsvRows();
        AssertNextItem<string>(items, assert);
    }

    private static void AssertListIsSorted<T>(IEnumerable<T> items)
        where T : IComparable<T>
    {
        AssertNextItem<T>(items, 
            (last, current) => Assert.IsTrue(last.CompareTo(current) <= 0,
            $"{last} is not less than {current}."));
    }

    private static void AssertNextItem<T>(IEnumerable<T> items, Action<T, T> assert)
    {
        IEnumerator<T> states = items.GetEnumerator();

        if (!states.MoveNext())
        {
            return;
        }
        T last = states.Current;
        while (states.MoveNext())
        {
            T current = states.Current;
            assert(last, current);
            last = states.Current;
        }
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_NoCommaOrSpaceAtEnd_Success()
    {
        string actual = SampleData.GetAggregateSortedListOfStatesUsingCsvRows();
        string expected = actual.Trim().Trim(',');

        Assert.AreEqual(expected,actual);
    }

    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_HasExpectedCountOfCommas_Success()
    {
        string expected = string.Join(", ", SampleData.GetUniqueSortedListOfStatesGivenCsvRows());
        string actual = SampleData.GetAggregateSortedListOfStatesUsingCsvRows();

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void People_AddressIsNotNull_Success()
    {
        IEnumerable<IPerson> people = SampleData.People;
        Assert.IsTrue(people.All(item => item.Address is not null));
    }

    [TestMethod]
    public void People_AreSortedByStateCityZip_Success()
    {
        IEnumerable<IPerson> people = SampleData.People;
        AssertListIsSorted<IAddress>(
            people.Select(item => item.Address));
    }

    [TestMethod]
    public void FilterByEmailAddress_FilterEduAddresses_Success()
    {
        Predicate<string> onlyEduEmail = item => item.ToLower().EndsWith("edu");
        IEnumerable<IPerson> personsWitEduEmail = SampleData.People.Where(
            person => onlyEduEmail(person.EmailAddress));
        IEnumerable<(string FirstName, string LastName)> actual = 
            SampleData.FilterByEmailAddress(onlyEduEmail);
        Assert.AreEqual(personsWitEduEmail.Count(), actual.Count());
        IEnumerable<(string FirstName, string LastName)> expected = personsWitEduEmail.Select(person => (person.FirstName, person.LastName));
        Assert.AreEqual(0, actual.Except(expected).Count());
    }
}