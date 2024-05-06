namespace Logger;

//because (I assume) we are supposed to extend the baseEntity in the entity classes, we cannot define implicit and explicit use of the IEntity members within these concrete classes
//This would be possible if we're supposed to directly implement the interface in the concrete classes, but if that was the case we would never want to create a base class in the first place.
//see: BaseEntity.cs
public abstract record class Person(FullName MyName) : BaseEntity, IEntity{
    public override string Name{
        get => MyName.ToString();
    }

}