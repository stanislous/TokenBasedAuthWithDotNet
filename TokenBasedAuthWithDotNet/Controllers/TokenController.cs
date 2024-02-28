using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TokenBasedAuthWithDotNet.Models;

namespace TokenBasedAuthWithDotNet.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IJwtTokenManager _jwtTokenManager;
    public TokenController(IJwtTokenManager jwtTokenManager)
    {
        _jwtTokenManager = jwtTokenManager;
    }

    [AllowAnonymous]
    [HttpPost("Authenticate")]
    public IActionResult Authenticate([FromBody] UserCredential userCredential)
    {
        var token = _jwtTokenManager.Authenticate(userCredential.Email, userCredential.Password);
        if (string.IsNullOrEmpty(token))
            return Unauthorized();
        return Ok(token);
    }
}