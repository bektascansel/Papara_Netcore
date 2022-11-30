using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Abstarccts;
using RepositoryPattern.Services.Concretes;
using System.Linq;

namespace RepositoryPattern.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService bookServices;

        public BookController(BookServices _bokservice)
        {
            bookServices = _bokservice;
        }

        //insert işlemi 
        [HttpPost]
        public IActionResult Post(Book book)
        {
            bookServices.Add(book);
            return Ok();
        }


        //select işlemi
        [HttpGet("Books")]
        public IActionResult Get()
        {
            var result = bookServices.GetAll().ToList();
            return Ok(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Book book)
        {
            bookServices.HardDelete(book);
            return Ok();
        }

        [HttpGet("GetById")]
        public IActionResult GetById(int id)
        {
            bookServices.GetById(id);
            return Ok();
        }
    }
}
