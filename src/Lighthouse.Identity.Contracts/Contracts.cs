namespace Lighthouse.Identity.Contracts;

public record DebitCoins(Guid UserId, int Coins, Guid CorrelationId);
public record CoinsDebited(Guid CorrelationId);
