namespace EventProject.Common.Events
{
    public sealed class Event1 : DomainEvent
    {
        public Event1(Guid id) : base(id) { }
    }
}
