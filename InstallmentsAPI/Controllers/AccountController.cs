﻿using InstallmentsAPI.Entities.Models;
using InstallmentsAPI.Entities.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InstallmentsAPI.Controllers;
[Route("api/[controller]")]
public class AccountController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> signInManager;
    private readonly IConfiguration configuration;

    public AccountController(UserManager<User> userManager, SignInManager<User> signInManager,
        IConfiguration configuration)
    {
        this.configuration = configuration;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }
    [Authorize(Policy = Policies.Admin)]
    [HttpPost("create/user/moderator")]
    public IActionResult RegisterUser([FromBody] UserSaveResource userAccount)
    {
        var user = new User()
        {
            Email = userAccount.Email,
            UserName = userAccount.UserName
        };
        userManager.CreateAsync(user, userAccount.Password).Wait();

        var registeredUser = userManager.FindByNameAsync(user.UserName).Result;
        userManager.AddToRoleAsync(registeredUser, Policies.Moderator).Wait();
        return Ok(new
        {
            registeredUser.Id,
            registeredUser.Email,
            registeredUser.UserName,
            Roles = userManager.GetRolesAsync(registeredUser).Result,
        });
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] UserSaveResource userAccount)
    {
        var userFromDb = userManager.FindByEmailAsync(userAccount.Email).Result;
        var result = signInManager.CheckPasswordSignInAsync(userFromDb, userAccount.Password, false).Result;


        if (result.Succeeded)
        {
            var tokenString = GenerateJSONWebToken(userFromDb);
            return Ok(new
            {
                userFromDb.Id,
                userFromDb.Email,
                userFromDb.UserName,
                Roles = userManager.GetRolesAsync(userFromDb).Result,
                tokenString
            });
        }

        return Unauthorized();
    }
    private string GenerateJSONWebToken(User user)
    {
        var claims = new List<Claim>();
        var roles = userManager.GetRolesAsync(user).Result;
        claims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
        claims.Add(new Claim("id", user.Id.ToString()));
        claims.Add(new Claim("email", user.Email));
        claims.Add(new Claim("name", user.UserName));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddMinutes(240),
            SigningCredentials = credentials
        };
        return tokenHandler.WriteToken(tokenHandler.CreateToken(token));
    }
}
