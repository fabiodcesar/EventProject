using EventProject.Domain.Common.Events;

namespace EventProject.Domain.Events
{
    public sealed class Event2 : DomainEvent
    {
        public Event2(Guid id) : base(id) { }
    }
}