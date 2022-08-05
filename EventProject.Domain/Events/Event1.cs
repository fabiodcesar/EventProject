using EventProject.Domain.Common.Events;

namespace EventProject.Domain.Events
{
    public sealed class Event1 : Event
    {
        public Event1(Guid id) : base(id) { }
    }
}
