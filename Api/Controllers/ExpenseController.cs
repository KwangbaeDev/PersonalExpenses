using Core.Interfaces.Services;
using Core.Request.ExpenseModels;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class ExpenseController : BaseApiController
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateExpenseModel request)
    {
        var expense = await _expenseService.Add(request);
        return Ok(expense);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var expense = await _expenseService.GetById(id);
        return Ok(expense);
    }


    [HttpGet("filter")]
    public async Task<IActionResult> Filtered([FromQuery] FilterExpenseModel filter)
    {
        var expense = await _expenseService.GetFiltered(filter);
        return Ok(expense);
    }


    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateExpenseModel request)
    {
        var expense = await _expenseService.Update(request);
        return Ok(expense);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var expense = await _expenseService.Delete(id);
        return Ok(expense);
    }
}