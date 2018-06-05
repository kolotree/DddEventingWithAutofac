using System.Collections.Generic;

namespace Domain
{
    public interface IEventDispatcher
    {
        IReadOnlyList<IDomainEvent> DispatchAll(IReadOnlyList<IDomainEvent> domainEvents);
    }
}