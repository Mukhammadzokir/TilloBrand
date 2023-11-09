using Microsoft.AspNetCore.Mvc;
using TilloBrand.Api.Responses;
using TilloBrand.Service.DTOs.Users;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Api.Controllers;

public class UsersController : BaseController
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        this._userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var response = new Response()
        {
            StatusCode = 200,
            Message = "Success",
            Data = await this._userService.GetAllAsync()
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
