using AuthorAndBook.Dto;
using AuthorAndBook.Models;
using AuthorAndBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAndBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorDetailsController : ControllerBase
    {
        private readonly IAuthorDetailsService _service;
        public AuthorDetailsController(IAuthorDetailsService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public IActionResult Post(AuthorDetailDto details)
        {
            return Ok(_service.Add(details));
        }
        [HttpPut]
        public IActionResult Put(AuthorDetailDto detail)
        {
            return Ok(_service.Update(detail));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
                return Ok();
            return NotFound("No AuthorDetails found!");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
    }
}
