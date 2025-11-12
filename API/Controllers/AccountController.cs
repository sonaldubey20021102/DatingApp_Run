using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interface;
using API.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController(AppDbContext context,ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")] // api/account/register
        public async Task<ActionResult<UserDto>> Register(RegisterUser registerUser)
        {
            if(await UserExists(registerUser.Email)) return BadRequest("Email is already taken");
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
                Email = registerUser.Email,
                UserName = registerUser.displayName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerUser.Password)),
                PasswordSalt = hmac.Key
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.ToDto(tokenService);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Users.SingleOrDefaultAsync(x => x.Email == loginDto.email);
            if (user == null) return Unauthorized("Invalid email");
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var ComputeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));
            for (int i = 0; i < ComputeHash.Length; i++)
            {
                if (ComputeHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }
            return user.ToDto(tokenService);
        }
        private async Task<bool> UserExists(string Email)
        {
            return await context.Users.AnyAsync(x => x.Email.ToLower() == Email.ToLower());
        }
    }
}
