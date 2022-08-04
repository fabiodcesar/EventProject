namespace EventProject.Domain.Common.Events
{
    public sealed class ErrorEvent : Event
    {
        private readonly string[] _errors;
        public ErrorEvent(string[] errors)
        {
            _errors = errors;
        }

        public string[] Errors { get { return _errors; } }
    }
}