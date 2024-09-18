using Demo_Media_Formatter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo_Media_Formatter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book() {Id = 1, Title = "Book One", Author = "Duyen", Year = 2000},
            new Book() {Id = 2, Title = "Book Two", Author = "Hien", Year = 2001},
            new Book() {Id = 3, Title = "Book Three", Author = "Nhu", Year = 2002},
            new Book() {Id = 4, Title = "Book Four", Author = "Tuan", Year = 2003},
            new Book() {Id = 5, Title = "Book Five", Author = "Nhat", Year = 2004},
        };

        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById([FromRoute] int id)
        {
            var book = Books.Find(book => book.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book newBook)
        {
            newBook.Id = Books.Count + 1; // Simulate automatical increament id
            Books.Add(newBook);

            return CreatedAtAction(nameof(GetBookById), new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public ActionResult<Book> UpdateBook([FromRoute] int id, [FromBody] Book updatedBook)
        {
            var existingBook = Books.Find(book => book.Id == id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = updatedBook.Title;
            existingBook.Author = updatedBook.Author;
            existingBook.Year = updatedBook.Year;

            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public ActionResult<Book> DeleteBook([FromRoute] int id)
        {
            var deletedBook = Books.Find(book => book.Id == id);

            if (deletedBook == null)
            {
                return NotFound();
            }

            Books.Remove(deletedBook);

            return NoContent();
        }
    }
}
