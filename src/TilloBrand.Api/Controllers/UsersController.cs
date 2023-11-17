using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TilloBrand.Api.Responses;
using TilloBrand.Service.Configurations;
using TilloBrand.Service.DTOs.Users;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Api.Controllers;

public class UsersController : BaseController
{
    private readonly IRepository _userService;

    public UsersController(IRepository userService)
    {
        this._userService = userService;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userService.GetAllAsync(@params)
        };
        return Ok(response);
    }

    [HttpGet("{id}")]

    public async Task<IActionResult> GetAsync([FromRoute] long id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userService.GetByIdAsync(id)
        };
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] UserForCreationDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userService.CreateAsync(dto)
        };
        return Ok(response);
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> DeleteAsync([FromRoute] long id)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userService.RemoveAsync(id)
        };
        return Ok(response);
    }
    [HttpPut("{id}")]

    public async Task<IActionResult> PutAsync([FromRoute] long id, [FromBody] UserForUpdateDto dto)
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userService.UpdateAsync(id, dto)
        };
        return Ok(response);
    }
}
