using Core.Interfaces.Services;
using Core.Request;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ExpenseCategoryController : BaseApiController
{
    private readonly IExpenseCategoryService _expenseCategoryService;

    public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService)
    {
        _expenseCategoryService = expenseCategoryService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExpenseCategoryModel request)
    {
        var category = await _expenseCategoryService.Add(request);
        return Ok(category);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var category = await _expenseCategoryService.GetById(id);
        return Ok(category);
    }


    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered([FromQuery] FilterExpenseCategoryModel filter)
    {
        var category = await _expenseCategoryService.GetFiltered(filter);
        return Ok(category);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateExpenseCategoryModel request)
    {
        var category = await _expenseCategoryService.Update(request);
        return Ok(category);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var category = await _expenseCategoryService.Delete(id);
        return Ok(category);
    }
}