using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shuru.API.Controllers
{
    public class BooksController : BaseController
    {
        [HttpGet("books")]
        public async Task<IActionResult> Get()
        {

        }

        [HttpPost("books")]
        public async Task<IActionResult> Create()
        {

        }

        [HttpPut("books/{bookId:int}")]
        public async Task<IActionResult> Update(int bookId)
        {

        }

        [HttpDelete("books/{bookId:int}")]
        public async Task<IActionResult> Delete(int bookId)
        {

        }
    }
}
