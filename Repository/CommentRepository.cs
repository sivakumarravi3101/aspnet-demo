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
    }
}