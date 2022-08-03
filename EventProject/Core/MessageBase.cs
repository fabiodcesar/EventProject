using MediatR;

namespace EventProject
{
    public abstract class MessageBase : INotification
    {
        public Guid Id { get; protected set; }
        public MessageBase(Guid id)
        {
            Id = id;
        }
    }
}
