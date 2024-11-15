using AuthorAndBook.Dto;
using AuthorAndBook.Models;
using AuthorAndBook.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthorAndBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetAll());
        }
        [HttpPost]
        public IActionResult Post(BookDto bookDto)
        {
            return Ok(_service.Add(bookDto));
        }
        [HttpPut]
        public IActionResult Put(BookDto book)
        {
            return Ok(_service.Update(book));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_service.Delete(id))
                return Ok();
            return NotFound("No Book found!");
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_service.GetById(id));
        }
        [HttpGet("GetAuthorByBookId/{id}")]
        public IActionResult GetAuthorByBookId(int id)
        {
            return Ok(_service.GetAuthorByBookId(id));
        }
    }
}
