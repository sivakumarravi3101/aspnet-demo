using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.DTOs.comment;
using demo.models;

namespace demo.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
               Id=commentModel.Id,
               Title=commentModel.Title,
               Content=commentModel.Content,
               CreatedOn=commentModel.CreatedOn,
               StockId=commentModel.StockId, 
            };
        }
        public static Comment ToCommentFromCreate(this CreateCommentRequest createComment,int StockId)
        {
            return new Comment
            {
                Title=createComment.Title,
                Content=createComment.Content,
                StockId=StockId,
            };
        }
        public static Comment ToCommentFromUpdate(this UpdateStockRequestDto updateComment)
        {
            return new Comment
            {
                Title=updateComment.Title,
                Content=updateComment.Content,
               
            };
        }
    }
}