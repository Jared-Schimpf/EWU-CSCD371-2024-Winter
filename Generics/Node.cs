using System.Collections;

namespace Generics;
public class Node<T> : IEnumerable<Node<T>>
{
    // An instance method that the caller can change to do something else when the
    // value is updated
    public Action<T>? Action { get; set; } = Update;
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

    public Node<T> Next { get; private set; }

    public Node(T value, Action<T>? action = null)
    {
        Action = action;
        // Invokes the method that is registered for Action to call
        Action?.Invoke(value);

        Value = value;
    }

    public static void Update(T value)
    {
    }

    public IEnumerator<Node<T>> GetEnumerator()
    {
        yield return Next;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    //IEnumerator IEnumerable.GetEnumerator()
    //{
    //    throw new NotImplementedException();
    //}

    //IEnumerable<Node<T>> GetRemainingItems()
    //{
    //    yield return Next;
    //}
}
