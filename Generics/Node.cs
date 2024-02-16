namespace Generics;
public class Node<T>
{
    Action<T?> Action = Update;
    public T Value { get; }

    public Node(T value)
    {
        Value = value;
    }

    public static void Update(T? value)
    {
    }
}
