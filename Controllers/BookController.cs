using BookStore_V2.Models;
using BookStore_V2.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore_V2.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookController : ControllerBase
{

    private readonly ILogger<BookController> _logger;
    private readonly IBookRepository _bookRepository;

    public BookController(ILogger<BookController> logger,
                                IBookRepository bookRepository)
    {
        _logger = logger;
        _bookRepository = bookRepository;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookRepository.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookDetailsById(int id)
    {
        var book = await _bookRepository.GetBookDetailsById(id);
        if (book == null)
        {
            return NotFound("Please Enter Current Number..!");
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDto model)
    {
        var id = await _bookRepository.CreateBook(model);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto model, int id)
    {
        var result = await _bookRepository.UpdateBook(id, model);
        if (result == true)
        {
            return Ok(result);
        }
        return BadRequest("This Number is not in this Rang!");

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveBook(int id)
    {
        var result = await _bookRepository.RemoveBook(id);
        if (result == true)
        {
            return Ok(true);
        }
        return BadRequest("book is not");
    }
}

