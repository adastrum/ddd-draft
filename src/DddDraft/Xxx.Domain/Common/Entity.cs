using System.Collections.Generic;

namespace Xxx.Domain.Common
{
    public abstract class Entity
    {
        public List<IDomainEvent> DomainEvents { get; private set; }

        public int Id { get; private set; }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            DomainEvents = DomainEvents ?? new List<IDomainEvent>();
            DomainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvent domainEvent)
        {
            DomainEvents?.Remove(domainEvent);
        }
    }
}
