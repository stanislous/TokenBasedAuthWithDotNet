using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TokenBasedAuthWithDotNet.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class NameController : ControllerBase
{
    [HttpGet("GetNames")]
    [Authorize]
    public IActionResult GetNames()
    {
        return Ok(new List<string> { "Adam", "Robert" });
    }
}