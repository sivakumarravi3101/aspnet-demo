using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Data;
using demo.interfaces;
using demo.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace demo.Repository
{
    
    
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDB_Context _Context;
        public CommentRepository(ApplicationDB_Context Context)
        {
            _Context=Context;
        }

        public async Task<Comment?> CreateAsync(Comment commentModel)
        {
            await _Context.comments.AddAsync(commentModel);
            await _Context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment?> DeleteAsync(int id)
        {
         var comment=   await _Context.comments.FirstOrDefaultAsync(c=>c.Id==id);
            if (comment == null)
            {
                return  null;
            }
             _Context.comments.Remove(comment);
             await _Context.SaveChangesAsync();
             return comment;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
         var comments= await _Context.comments.ToListAsync();
         return comments;
        }

        public async Task<Comment> GetCommentById(int id)
        {
          var data= await _Context.comments.FindAsync(id);
           return data;
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
           var existingComment=await  _Context.comments.FindAsync(id);
            if (existingComment == null)
            {
                return null;
            }
            existingComment.Title=commentModel.Title;
            existingComment.Content=commentModel.Content;
            await _Context.SaveChangesAsync();
            return existingComment;
        }
    }
}