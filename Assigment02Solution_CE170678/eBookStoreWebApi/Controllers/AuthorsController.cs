using BusinessObject;
using BusinessObject.DTOs;
using BusinessObject.Mappers;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eBookStoreWebApi.Controllers
{
    [Route("odata/[controller]")]
    public class AuthorsController : ODataController
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        [EnableQuery]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        [HttpGet("{id}")]
        [EnableQuery]
        public IActionResult GetAuthorById([FromRoute] int id)
        {
            var author = _authorRepository.GetAuthorById(id);

            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        [HttpPost]
        public ActionResult CreateAuthor([FromBody] CreateAuthorDto dto)
        {
            var author = dto.ToEntityAuthor();

            var existingAuthor = _authorRepository.GetAuthorById(author.author_id);

            if (existingAuthor == null)
            {
                _authorRepository.AddAuthor(author);
            }
            else
            {
                return BadRequest("The author is already exist!");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor([FromRoute] int id, [FromBody] CreateAuthorDto dto)
        {
            var author = dto.ToEntityAuthor();
            var existingAuthor = _authorRepository.GetAuthorById(id);
            if (existingAuthor == null) return NotFound();


            _authorRepository.UpdateAuthor(id, author);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor([FromRoute] int id)
        {
            var existingAuthor = _authorRepository.GetAuthorById(id);
            if (existingAuthor == null) return NotFound();

            _authorRepository.DeleteAuthor(id);
            return NoContent();
        }
    }
}
