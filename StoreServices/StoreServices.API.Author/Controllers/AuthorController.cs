using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoreServices.API.Author.Application;
using System;
using System.Threading.Tasks;

namespace StoreServices.API.Author.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create(New.Execute request)
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

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new Get.AuthorList()));
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(Guid representative)
        {
            try
            {
                return Ok(await _mediator.Send(new Filter.AuthorFiltered { AuthorRepresentative = representative }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
