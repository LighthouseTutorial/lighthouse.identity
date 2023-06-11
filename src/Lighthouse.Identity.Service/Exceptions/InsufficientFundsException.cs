using System;
using System.Runtime.Serialization;

namespace Lighthouse.Identity.Service.Consumers
{
    [Serializable]
    internal class InsufficientFundsException : Exception
    {
        public Guid UserId { get; }
        public int Coins { get; }

        public InsufficientFundsException(Guid userId, int coins)
            : base($"Not enough coins to debit {coins} from user '{userId}")
        {
            this.UserId = userId;
            this.Coins = coins;
        }
    }
}