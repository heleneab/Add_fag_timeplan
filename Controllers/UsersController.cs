using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Example.Data;
using Example.Models;

namespace Example.Controllers;

public class UsersController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<ApplicationUser> _um;
    private readonly IMapper _mapper;

    // Dependency inject both the db context and the user manager for use in actions
    public UsersController(ApplicationDbContext db, UserManager<ApplicationUser> um, IMapper mapper)
    {
        _db = db;
        _um = um;
        _mapper = mapper;
    }

    // Creates user from API request
    [HttpPost("api/[controller]")]
    public async Task<IActionResult> PostAuthor([FromBody] ApplicationUserDto au)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        // Auto mapper copies matching properties from one object to another.
        // See Program.cs and MapperProfile.cs for required configuration.
        var user = _mapper.Map<ApplicationUser>(au);
        
        await _um.CreateAsync(user, au.Password);

        return Ok();

    }
}
