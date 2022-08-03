using MediatR;

namespace EventProject
{
    public class DomainErrors : Message
    {
        private readonly List<string> errorList;
        public DomainErrors() : base(Guid.NewGuid())
        {
            errorList = new List<string>();
        }

        public string[] Errors { get { return errorList.ToArray(); } }

        public void AddError(string errorMessage)
        {
            errorList.Add(errorMessage);
        }
    }

    public class DomainErrorsHandler : INotificationHandler<DomainErrors>
    {
        public async Task Handle(DomainErrors domainErrors, CancellationToken cancellationToken)
        {
            if (domainErrors.Errors == null)
                return;

            var sb = new System.Text.StringBuilder();
            foreach (var error in domainErrors.Errors)
            {
                sb.AppendLine(error);
            }
            throw new DomainException(sb.ToString());
        }
    }
}