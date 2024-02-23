using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics.Tests;
public class NodeTests
{
    [Fact]
    public void IterateOverNode()
    {
        Node<string> node = new Node<string>("Thing");
        node.Append(new Node<string>("Hello"));

        IEnumerable<Node<string>> items = 
            node.Where(item => item.Value == "Thing");

        int itemCount = node.Count();

        IEnumerable<Person> persons = new List<Person>();

        persons  = persons.Where(person => person.LastName == "Montoya");

        IEnumerable<FullName> names = 
            persons.Select(person => new FullName(person.FirstName, person.LastName));

        names = persons.Select(person => person.Name);

        IEnumerable<(string theFirstName, string lastName)> firstLastNames =
            persons.Select(person => (person.FirstName, person.LastName));

        string firstName = firstLastNames.First().theFirstName;

        // How many times have we iterated over "persons" to return names.
        // persons has lets say (100 items) (irrelevant)
        names  = persons.Where(person => person.LastName == "Montoya")
                        .Select(person => person.Name);

        IEnumerable<Person> thing = persons.Where(person => person.LastName == "Montoya");
        IEnumerable<FullName> thing2 = thing.Select(person => person.Name);
        IEnumerable<FullName> thing3 = thing2.ToList();
        FullName thing4 = thing3.First();
        int thing5 = thing3.Count();





        foreach (Node<string> item in
            items)
        {


        }
    }
}
