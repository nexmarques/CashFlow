﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredExpenseJson),StatusCodes.Status201Created)]
    public IActionResult Register([FromBody] RequestRegisterExpenseJson request)
    {

        try
        {
            var useCase = new RegisterExpenseUseCase();
            var response = useCase.Execute(request);
            return Created(string.Empty, response);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
        catch
        {
            return StatusCode(StatusCodes.Status500InternalServerError, "Unknown error");
        }
    }
}
