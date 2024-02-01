using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public interface ISerializable
    {
        string Serialize(string input);
        string Deserialize(string input);
    }
}