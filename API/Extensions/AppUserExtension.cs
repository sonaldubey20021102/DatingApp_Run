
using API.DTOs;
using API.Entities;
using API.Interface;


namespace API.Extensions;

public static class AppUserExtension
{
    public static UserDto ToDto(this AppUser user, ITokenService tokenService)
    {
        return new UserDto
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            Token = tokenService.CreateToken(user)
        };
    }
}
