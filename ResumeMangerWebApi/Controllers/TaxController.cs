﻿using Microsoft.AspNetCore.Mvc;
using ResumeMangerWebApi.Implementation.Interfaces;

[Route("api/[controller]")]
[ApiController]
public class TaxController : ControllerBase
{
    private readonly ITaxService _taxService;

    public TaxController(ITaxService taxService)
    {
        _taxService = taxService;
    }

    [HttpPost("calculate-paye")]
    public IActionResult CalculatePAYE([FromBody] Anthonia_PAYE model)
    {
        if (model == null || model.Income <= 0)
        {
            return BadRequest("Invalid income data.");
        }

        model.Tax = _taxService.CalculatePAYE(model.Income);
        return Ok(new { income = model.Income, tax = model.Tax });
    }
}
