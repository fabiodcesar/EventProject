using MediatR;

namespace EventProject
{
    public class ErrorEvent : INotification
    {
        private readonly string[] _errors;
        public ErrorEvent(string[] errors)
        {
            _errors = errors;
        }

        public string[] Errors { get { return _errors; } }
    }

    public class ErrorEventHandler : INotificationHandler<ErrorEvent>
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
            throw new ArgumentException(errors);
        }
    }
}