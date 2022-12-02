using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebApi_Dapper.Services.Abstrcats;
using WebApi_Dapper.Data.DTO;

namespace WebApi_Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _IBookService;

        public BookController(IBookService bookService)
        {
            _IBookService = bookService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(string  name, string writeName)
        {
            await _IBookService.CreateAsync(new CreateUpdateBookDto { Name=name, WriteName = writeName });
            var book = await _IBookService.GetBooksAsync();

            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAsync(Guid id, string name, string writeName, int pageNumber)
        {
            await _IBookService.UpdateAsync(id, new CreateUpdateBookDto { Name = name, WriteName = writeName, PageNumber = pageNumber });

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
        {
            await _IBookService.DeleteAsync(id);
            var book = await _IBookService.GetBooksAsync();

            return Ok(book);
        }

        [HttpGet("GetBook")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _IBookService.GetAsync(id);
            return Ok(book);

        }

        [HttpGet("BookList")]
        public async Task<IActionResult> GetAllBook()
        {
            var bookList = await _IBookService.GetBooksAsync();
            return Ok(bookList);

        }

    }
}
