﻿using EventProject.Core.Handlers;
using MediatR;

namespace EventProject.Core.Publishers
{
    public interface IPublisher
    {
        Task ThrowErrors(string[] errors);
    }

    public abstract class Publisher : IPublisher
    {
        protected readonly IMediator _mediator;

        public Publisher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ThrowErrors(string[] errors)
        {
            await _mediator.Publish(new ErrorEvent(errors));
        }
    }
}
