using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Controllers;

public class SecretController : ControllerBase
{
    [Authorize]
    [HttpGet("api/[controller]")]
    public IActionResult Index()
    {
        return Ok();
    }
}