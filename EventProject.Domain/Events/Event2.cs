using EventProject.Domain.Common.Events;

namespace EventProject.Domain.Events
{
    public sealed class Event2 : Event
    {
        public Event2(Guid id) : base(id) { }
    }
}