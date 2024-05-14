namespace GenericsHomework;
public class Node<T>
{
    public T Data{get; set;}
    public Node<T> Next{get; private set;}

    public Node(T data){
        Data = data;//no validation means that we're allowing this to potentially be null?
        Next = this;
    }

    public void Append(T data){
        if(Exists(data)) throw new ArgumentException("Value already exists in list", nameof(data));

        Node<T> newNode = new(data)
        {
            Next = this.Next //the this keyword is redundant but I find it more readable
        };
        Next = newNode;
    }

    public bool Exists(T value){ 
        Node<T> current = this;

        if(value == null) do{
            if(current.Data == null){//since we're allowing our nodes to contain null values I'm seperating the check for null to avoid errors
                return true;
            }
            current = current.Next;

         }while(!current.Equals(this));
        
        else do{
            if(current.Data != null && current.Data.Equals(value)){   
                return true;
            }

            current = current.Next;
        }while(!current.Equals(this));

        return false;
    }
    public void Clear(){
        Next = this; //.NET's garbage collection is sophisticated enough to handle circular references
        
        /*
        removed items don't have to circle back to themselves, because even though they can reach this node at the end of their chain of Next references,
        there isn't any references to the start of said chain anymore (the node this.Next used to point to) and thus the whole chain is unreachable and gets compacted over
        by garbage collection.
        
        Even though A -> B -> C -> this, since nothing points to A, and A isn't a root reference, A, B, and C will never get added to the tree of reachable objects
        */
    }

    public override string ToString(){   
        return (Data == null) ? "null": Data.ToString() ?? "null"; //I wonder if theres a more elegant way to do this, but I think this is concise enough
    }

}
