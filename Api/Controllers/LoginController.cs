using Core.Interfaces.Services;
using Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class LoginController : BaseApiController
{
    private readonly IJwtProvider _jwtProvider;

    public LoginController(IJwtProvider jwtProvider)
    {
        _jwtProvider = jwtProvider;
    }

    [HttpPost ("token")]
    public async Task<IActionResult> GetToken(CreateLoginModel request)
    {
        var result = await _jwtProvider.GetToken(request);
        return Ok(result);
    }
}