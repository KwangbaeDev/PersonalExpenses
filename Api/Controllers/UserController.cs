using Core.Interfaces.Services;
using Core.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


public class UserController : BaseApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserModel request)
    {
        // var user = await _userService.Add(request);
        // return Ok(user);
        return Ok(await _userService.Add(request));
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await _userService.GetById(id);
        return Ok(user);
    }


    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterUserModel filter)
    {
        var user = await _userService.GetFiltered(filter);
        return Ok(user);
    }


    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var user = await _userService.GetAll();
        return Ok(user);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserModel request)
    {
        var user = await _userService.Update(request);
        return Ok(user);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var user = await _userService.Delete(id);
        return Ok(user);
    }

}