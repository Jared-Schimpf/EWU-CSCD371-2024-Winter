using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger;
public abstract class EntityBase : IEntity
{
    private Guid _InternalId = Guid.NewGuid();
    Guid IEntity.Id { get => _InternalId; init => _InternalId = value; }   

    public EntityBase(Guid id) 
    {
        _InternalId = id;
    }
    public EntityBase() { }

    static void DoSomething()
    {
        Person person = new(42) { Id = 43 };
    }
}
