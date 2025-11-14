using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.DTOs.comment
{
    public class CommentDto
    {
        public int Id {set;get;}
        public string Title{get;set;}=string.Empty;
        public string Content{get;set;}=string.Empty;
        public DateTime CreatedOn{get;set;}=DateTime.Now;
        public int StockId{get;set;}
        
    }
}