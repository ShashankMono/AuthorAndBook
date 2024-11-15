using AuthorAndBook.Dto;
using AuthorAndBook.Models;
using AuthorAndBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAndBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get() {
            var authorDto = _service.GetAll();
            return Ok(authorDto);
        }
        [HttpPost]
        public IActionResult Post(AuthorDto authorDto) {
            
            return Ok(_service.Add(authorDto));
        }
        [HttpPut]
        public IActionResult Put(AuthorDto authorDto) {
            var response = _service.Update(authorDto);
            if(response != null)
                return Ok(response);
            return NotFound("Author not found!");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) { 
            if(_service.Delete(id))
                return Ok();
            return NotFound("No Author found!");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name) {
            return Ok(_service.GetByName(name));
        }
        [HttpGet("GetDetailById/{id}")]
        public IActionResult GetDetailById(int id) {
            return Ok(_service.GetDetailById(id));
        }
        [HttpGet("GetBooksByAuthorId/{id}")]
        public IActionResult GetBooksByAuthorId(int id)
        {
            return Ok(_service.GetBooksByAuthorId(id));
        }
    }
}
