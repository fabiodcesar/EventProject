﻿namespace EventProject.Domain.Common.Events
{
    public abstract class DomainEvent : Event
    {
        public Guid Id { get; protected set; }
        public DomainEvent(Guid id)
        {
            Id = id;
        }
    }
}