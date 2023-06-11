using System;
using System.Runtime.Serialization;

namespace Lighthouse.Identity.Service.Consumers
{
    [Serializable]
    internal class UnknownUserException : Exception
    {
        public Guid UserId { get; }

        public UnknownUserException(Guid userId)
            : base($"Unknown user '{userId}'")
        {
            this.UserId = userId;
        }
    }
}