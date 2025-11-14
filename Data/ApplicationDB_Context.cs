using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.models;
using Microsoft.EntityFrameworkCore;

namespace demo.Data
{
    public class ApplicationDB_Context:DbContext
    {
        public ApplicationDB_Context(DbContextOptions dbContextOptions):base(dbContextOptions)
        { 
            
        }
        public DbSet<Stocks>stocks{get;set;}
        public DbSet<Comment>comments{get;set;}
    }
}