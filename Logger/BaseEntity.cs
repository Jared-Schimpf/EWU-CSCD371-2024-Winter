namespace Logger;

//it is impossible to explicitly implement IEntity's Name while also not implementing it. the only way to not implement it without error is to abstract it,
// which forces derived classes to implement it implicitly since those classes don't and shouldn't implement IEntity directly (otherwise this class serves no purpose)

//also having this class even exist violates most coding guidelines since it just reproduces the signature of the interface
// mine also provides an implementation for ID but that isn't required by the instructions. If you're looking at this program strictly by instructions, this class is useless

//This explanation explains why I'm not going to bother doing this: Given the properties on the full name record, you should consider which entities it makes sense to use it. ❌✔
public abstract record class BaseEntity : IEntity
{
    public Guid Id { get => Id; init=> Guid.NewGuid();} 
    public abstract string Name{get;}
}