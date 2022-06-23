using BookAPI.Models;
using BookAPI.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepos repos;

        public BooksController(IBookRepos repos)
        {
            this.repos = repos;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await repos.GetAllBookAsync();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute]int id)
        {
            var books = await repos.GetBookByIdAsync(id);
            return Ok(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody]BookModel book)
        {
            var books = await repos.AddBookAsync(book);
            return Ok(books);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook([FromRoute]int id,[FromBody] BookModel book)
        {
            await repos.UpdateBookAsync(id,book);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] int id)
        {
            await repos.DeleteBookAsync(id);
            return Ok();
        }
    }


}
