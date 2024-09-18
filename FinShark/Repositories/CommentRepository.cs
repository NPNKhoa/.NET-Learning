using FinShark.Data;
using FinShark.Dtos.Comment;
using FinShark.Helpers;
using FinShark.Interfaces;
using FinShark.Mappers;
using FinShark.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace FinShark.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();

            return commentModel;
        }

        public async Task<Comment?> UpdateAsync(int id, UpdateCommentDto commentDto)
        {
            var existingComment = await _context.Comments.FindAsync(id);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.Title = commentDto.Title;
            existingComment.Content = commentDto.Content;
            existingComment.CreatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingComment;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
            var deleteComment = await _context.Comments.FindAsync(id);

            if (deleteComment == null)
            {
                return null;
            }

            _context.Comments.Remove(deleteComment);

            await _context.SaveChangesAsync();

            return deleteComment;
        }
    }
}
