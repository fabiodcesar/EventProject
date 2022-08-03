using MediatR;

namespace EventProject
{
    public abstract class Message : INotification
    {
        public Guid Id { get; protected set; }
        public Message(Guid id)
        {
            Id = id;
        }
    }
}
