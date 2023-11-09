using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TilloBrand.Api.Responses;
using TilloBrand.Service.DTOs.Orders;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Api.Controllers;

public class OrdersController : BaseController
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        this._orderService = orderService;
    }

    [HttpGet]

    public async Task<IActionResult> GetAllAsync()
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.GetAllAsync()
        });

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.GetByIdAsync(id)
        });

    [HttpPost]

    public async Task<IActionResult> PostAsync([FromBody] OrderForCreationDto dto)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.CreateAsync(dto)
        });

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.RemoveAsync(id)
        });

    [HttpPut("{id}")]

    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] OrderForUpdateDto dto)
        => Ok(new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._orderService.UpdateAsync(id, dto)
        });
}
