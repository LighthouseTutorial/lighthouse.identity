using System;
using System.ComponentModel.DataAnnotations;

namespace Lighthouse.Identity.Service.Dtos;

public record UserDto
(
    Guid Id,
    string Username,
    string Email,
    int Coins,
    DateTimeOffset CreatedDate
);

public record UpdateUserDto
(
    [Required][EmailAddress] string Email,
    [Range(0, 1_000_000)] int Coins
);