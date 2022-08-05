using EventProject.Domain.Common.Events;

namespace EventProject.Domain.Events
{
    public sealed class Event3 : Event
    {
        public Event3(Guid id) : base(id) { }
    }
}