using System;
using System.Collections.Generic;

namespace Assignment
{
    public record class Address : IAddress
    {
        public Address(string streetAddress, string city, string state, string zip)
        {
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zip = zip;
        }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public int CompareTo(IAddress? other) => other is null ? 1 :
                (State, City, Zip).CompareTo((other.State, other.City, other.Zip));
    }
}
