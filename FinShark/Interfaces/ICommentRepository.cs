using FinShark.Dtos.Comment;
using FinShark.Helpers;
using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>> GetAllAsync();
        public Task<Comment?> GetByIdAsync(int id);
        public Task<Comment> CreateAsync(Comment commentModel);
        public Task<Comment?> UpdateAsync(int id, UpdateCommentDto commentDto);
        public Task<Comment?> DeleteAsync(int id);
    }
}
