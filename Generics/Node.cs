namespace Generics;
public class Node<T>
{
    // An instance method that the caller can change to do something else when the
    // value is updated
    public Action<T?>? Action { get; set; } = Update;
    private T _value;
    public T Value
    {
        get => _value;
        set
        {
            Action?.Invoke(value);
            _value = value;
        }
    }

    public Node(T value, Action<string?> action = null)
    {
        Action = action;
        // Invokes the method that is registered for Action to call
        Action?.Invoke(value);

        Value = value;
    }

    public static void Update(T? value)
    {
    }
}
