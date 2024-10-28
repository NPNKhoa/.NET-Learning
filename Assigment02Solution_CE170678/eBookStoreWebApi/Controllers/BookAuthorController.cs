using BusinessObject;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebApi.Controllers
{
    [Route("api/bookauthors")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class BookAuthorController : ControllerBase
    {
        private readonly IBookAuthorRepository _bookAuthorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        public BookAuthorController(IBookAuthorRepository bookAuthorRepository, IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _bookAuthorRepository = bookAuthorRepository;
        }

        [HttpPost]
        public IActionResult AddBookAuthor([FromBody] BookAuthor model)
        {
            if (ModelState.IsValid)
            {
                var book = _bookRepository.GetBookById(model.book_id);
                var author = _authorRepository.GetAuthorById(model.author_id);

                var flag = _bookAuthorRepository.CheckExistBookAuthor(model);

                if (book == null || author == null)
                {
                    return NotFound(new { message = "Book or Author not found." });
                }


                if (!flag)
                {
                    _bookAuthorRepository.AddBookAuthor(model);
                }
                else
                {
                    return Conflict("This Author is already added to this book before");
                }

                return Ok(new { message = "Author added successfully!" });
            }

            return BadRequest(ModelState);
        }

    }
}
