using System;

namespace Generics.Tests;
public class ThingFactory : Factory<TestThing>
{
    public override TestThing Create(string text) => new(text);
}

