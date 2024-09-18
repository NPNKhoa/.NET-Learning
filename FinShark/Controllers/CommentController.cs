using FinShark.Dtos.Comment;
using FinShark.Helpers;
using FinShark.Interfaces;
using FinShark.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace FinShark.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IStockRepository _stockRepo;

        public CommentController(ICommentRepository commentRepo, IStockRepository stockRepo)
        {
            _commentRepo = commentRepo;
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentRepo.GetAllAsync();

            var commentDto = comments.Select(s => s.ToCommentDto());

            return Ok(commentDto);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment.ToCommentDto());
        }

        [HttpPost]
        [Route("{stockId:int}")]
        public async Task<IActionResult> Create([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
                return BadRequest(ModelState);
            }

            if (!(await _stockRepo.StockExists(stockId)))
            {
                return BadRequest("Stock does not exist");
            }

            var comment = commentDto.ToCommentFromCreateDto(stockId);
            await _commentRepo.CreateAsync(comment);
            
            return CreatedAtAction(nameof(GetCommentById), new { id = comment }, comment.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto commentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedComment = await _commentRepo.UpdateAsync(id, commentDto);

            if (updatedComment == null)
            {
                return NotFound();
            }

            return Ok(updatedComment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var deletedComment = await _commentRepo.DeleteAsync(id);

            if (deletedComment == null)
            {
                return NotFound();
            }

            return Ok(deletedComment.ToCommentDto());
        }
    }
}
