using System.Threading.Tasks;
using Lighthouse.Identity.Contracts;
using Lighthouse.Identity.Service.Entities;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace Lighthouse.Identity.Service.Consumers;

public class DebitCoinsConsumer : IConsumer<DebitCoins>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public DebitCoinsConsumer(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<DebitCoins> context)
    {
        var message = context.Message;

        var user = await _userManager.FindByIdAsync(message.UserId.ToString());

        if (user is null)
        {
            throw new UnknownUserException(message.UserId);
        }

        user.Coins -= message.Coins;

        if (user.Coins < 0)
        {
            throw new InsufficientFundsException(message.UserId, message.Coins);
        }

        await _userManager.UpdateAsync(user);

        await context.Publish(new CoinsDebited(message.CorrelationId));
    }
}
