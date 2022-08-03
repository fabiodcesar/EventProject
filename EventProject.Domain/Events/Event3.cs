using EventProject.Domain.Common.Events;

namespace EventProject.Domain.Events
{
    public sealed class Event3 : DomainEvent
    {
        public Event3(Guid id) : base(id) { }
    }
}