
namespace Generics;

public static class Comparer
{
    //public static CompareResult Compare(this FullName fullName1, FullName fullName2)
    //{
    //    return string.Compare(fullName1.LastName, fullName2.LastName) switch
    //    {
    //        0 => CompareResult.Equal,
    //        > 0 => CompareResult.GreaterThan,
    //        < 0 => CompareResult.LessThan
    //    };
    //}

    //public static CompareResult Compare(this Person fullName1, Person fullName2)
    //{
    //    return string.Compare(fullName1.LastName, fullName2.LastName) switch
    //    {
    //        0 => CompareResult.Equal,
    //        > 0 => CompareResult.GreaterThan,
    //        < 0 => CompareResult.LessThan
    //    };
    //}
    //public static CompareResult DoSomething(params object[] args)
    //{
    //    var thing = ("", 1, 3, "");
    //}
    //public static CompareResult Compare(object left, object right)
    //{
    //    throw new NotImplementedException();
    //}



    public static CompareResult Compare<T>(this T left, T right)
        where T : IComparable => left.CompareTo(right) switch
        {
            0 => CompareResult.Equal,
            > 0 => CompareResult.GreaterThan,
            < 0 => CompareResult.LessThan
        };
}