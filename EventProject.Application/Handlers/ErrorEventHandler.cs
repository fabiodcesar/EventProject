using EventProject.Domain.Common.Events;
using EventProject.Domain.Common.Exceptions;
using MediatR;

namespace EventProject.Application.Handlers
{
    public class ErrorEventHandler : EventHandlerBase, INotificationHandler<ErrorEvent>
    {
        public async Task Handle(ErrorEvent errorEvent, CancellationToken cancellationToken)
        {
            if (errorEvent.Errors == null || errorEvent.Errors.Length == 0)
            {
                throw new Exception($"{typeof(ErrorEventHandler).Name}: error colletion should not be empty");
            }

            var sb = new System.Text.StringBuilder();
            foreach (var error in errorEvent.Errors)
            {
                sb.AppendLine(error);
            }

            var errors = sb.ToString();

            //TODO: This is not working!!!
            throw new DomainException(errors);
        }
    }
}