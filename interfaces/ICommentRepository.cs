using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.models;

namespace demo.interfaces
{
    public interface ICommentRepository
    {
        public Task<List<Comment>>GetAllAsync();

       public Task<Comment> GetCommentById(int id);

       public Task<Comment?>CreateAsync(Comment commentModel);

       public Task<Comment?>UpdateAsync(int id,Comment commentModel);

       public Task<Comment?>DeleteAsync(int id);
    }
}