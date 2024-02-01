using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logger
{
    public class Service : ILogger, IEnumerable
    {
        List<string> thing = new();
    }
}