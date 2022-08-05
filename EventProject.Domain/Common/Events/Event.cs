using MediatR;

namespace EventProject.Domain.Common.Events
{
    public abstract class Event : INotification
    {
        public Guid Id { get; protected set; }
        public Event(Guid id)
        {
            Id = id;
        }
    }

}
