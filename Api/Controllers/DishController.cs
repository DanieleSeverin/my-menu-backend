﻿using Application.Dishes.SearchDishesByMenu;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class DishController : ControllerBase
{
    private readonly ISender _sender;

    public DishController(ISender sender)
    {
        _sender = sender;
    }

    [AllowAnonymous]
    [HttpGet("MenuId")]
    public async Task<IActionResult> SearchDishesByMenu(Guid MenuId, CancellationToken cancellationToken) 
    {
        var query = new SearchDishesByMenuQuery(MenuId);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }
}
