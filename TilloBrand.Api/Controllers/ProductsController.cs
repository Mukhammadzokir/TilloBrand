using Microsoft.AspNetCore.Mvc;
using TilloBrand.Api.Responses;
using TilloBrand.Service.DTOs.Products;
using TilloBrand.Service.Interfaces;

namespace TilloBrand.Api.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _productService.GetAllAsync()
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
                Data = await _productService.GetByIdAsync(id)
            };
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] ProductForCreationDto dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _productService.CreateAsync(dto)
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
                Data = await _productService.RemoveAsync(id)
            };
            return Ok(response);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> PutAsync([FromRoute] long id, [FromForm] ProductForUpdateDto dto)
        {
            var response = new Response()
            {
                StatusCode = 200,
                Message = "Success",
                Data = await _productService.UpdateAsync(id, dto)
            };
            return Ok(response);
        }
        //Added
    }
}
