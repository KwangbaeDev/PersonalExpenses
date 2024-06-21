using Core.Interfaces.Services;
using Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class LoginController : BaseApiController
{
    private readonly ILoginService _loginService;
    private readonly IJwtProvider _jwtProvider;

    public LoginController(ILoginService loginService ,IJwtProvider jwtProvider)
    {
        _loginService = loginService;
        _jwtProvider = jwtProvider;
    }

    [HttpPost ("auth")]
    public async Task<IActionResult> AuthUser(CreateLoginModel request)
    {
        var login = await _loginService.AuthUser(request);


        var result = _jwtProvider.Generate(login);
        return Ok(result);
    }
}