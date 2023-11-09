using Microsoft.AspNetCore.Mvc;
using TilloBrand.Api.Responses;
using TilloBrand.Service.DTOs.Markets;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Api.Controllers;

public class MarketsController : BaseController
{
    private readonly IMarketService _marketService;

    public MarketsController(IMarketService marketService)
    {
        this._marketService = marketService;
    }

    [HttpGet]

    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._marketService.GetAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._marketService.GetByIdAsync(id)
        });

    [HttpPost]

    public async Task<IActionResult> PostAsync([FromBody] MarketForCreationDto dto)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._marketService.CreateAsync(dto)
        });

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._marketService.RemoveAsync(id)
        });

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] MarketForUpdateDto dto)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._marketService.UpdateAsync(id,dto)
        });
}
