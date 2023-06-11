using Lighthouse.Identity.Service.Dtos;
using Lighthouse.Identity.Service.Entities;

namespace Lighthouse.Identity.Service;

public static class Extensions
{
    public static UserDto AsDto(this ApplicationUser user)
    {
        return new UserDto
        (
            user.Id,
            user.UserName,
            user.Email,
            user.Coins,
            user.CreatedOn
        );
    }
}