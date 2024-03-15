using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.API.Cart.Application;
using StoreServices.API.Cart.Dtos;
using System;
using System.Threading.Tasks;

namespace StoreServices.API.Cart.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CartController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(New.Execute request)
        {
            try
            {
                return Ok(await _mediator.Send(request));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetCartById(int id)
        {
            try
            {
                return Ok(await _mediator.Send(new Get.Execute { CartSessionId = id }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
