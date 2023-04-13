using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Example.Data;
using Example.Models;

namespace Example.Controllers;

public class LoginController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _um;
    private readonly IConfiguration _config;

    // The final parameter injects the configuration, which is read from appsettings.json
    public LoginController(ApplicationDbContext db, UserManager<ApplicationUser> um, IConfiguration config)
    {
        _db = db;
        _um = um;
        _config = config;
    }

    // Log in a user from an API request
    [HttpPost("api/[controller]")]
    public async Task<IActionResult> PostAuthor([FromBody] LoginDto login)
    {
        var user = await _um.FindByNameAsync(login.UserName);

        if (user == null)
            return Unauthorized();
        
        bool result = await _um.CheckPasswordAsync(user, login.Password);

        if (!result)
            return Unauthorized();

        // User is authenticated, return JWT token
        
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Secret"]));
  
        var token = new JwtSecurityToken(  
            issuer: _config["JwtSettings:Issuer"],  
            audience: _config["JwtSettings:Audience"],  
            expires: DateTime.Now.AddDays(int.Parse(_config["JwtSettings:ValidityDays"])),
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)  
        );  
  
        return Ok(new  
        {  
            token = new JwtSecurityTokenHandler().WriteToken(token),  
            expiration = token.ValidTo  
        });
    }
}
