using BusinessObject;
using BusinessObject.DTOs;
using BusinessObject.Mappers;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebApi.Controllers
{
    namespace eBookStoreWebApi.Controllers
    {
        [Route("odata/[controller]")]
        public class BooksController : ODataController
        {
            private readonly IBookRepository _bookRepository;

            public BooksController(IBookRepository bookRepository)
            {
                _bookRepository = bookRepository;
            }

            [HttpGet]
            [EnableQuery]
            public ActionResult<IEnumerable<Book>> GetAllBooks()
            {
                return _bookRepository.GetAllBooks();
            }

            [HttpGet("publishers")]
            public ActionResult<IEnumerable<Publisher>> GetAllPublishers()
            {
                return _bookRepository.GetAllPublishers();
            }

            [HttpGet("authors")]
            public ActionResult<IEnumerable<Author>> GetAllAuthors()
            {
                return _bookRepository.GetAllAuthors();
            }

            [HttpGet("{id}")]
            public IActionResult GetBookById([FromRoute] int id)
            {
                var book = _bookRepository.GetBookById(id);

                if (book == null)
                {
                    return NotFound();
                }

                return Ok(book);
            }

            [HttpPost]
            public ActionResult CreateBook([FromBody] CreateBookDto dto)
            {
                var book = dto.ToEntityBook();

                var existingBook = _bookRepository.GetBookById(book.book_id);

                if (existingBook == null)
                {
                    _bookRepository.AddBook(book);
                }
                else
                {
                    return BadRequest("The book already exists!");
                }
                return NoContent();
            }

            [HttpPut("{id}")]
            public IActionResult UpdateBook([FromRoute] int id, [FromBody] CreateBookDto dto)
            {
                var book = dto.ToEntityBook();
                var existingBook = _bookRepository.GetBookById(id);
                if (existingBook == null) return NotFound();

                _bookRepository.UpdateBook(id, book);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteBook([FromRoute] int id)
            {
                var existingBook = _bookRepository.GetBookById(id);
                if (existingBook == null) return NotFound();

                _bookRepository.DeleteBook(id);
                return NoContent();
            }
        }
    }

}
