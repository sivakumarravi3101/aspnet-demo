using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.DTOs.comment;
using demo.interfaces;
using demo.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace demo.contollers
{
   [Route("api/comment")]
   [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentRepository _CommentRepo;
        private readonly IStockRepository _stockRepo;
        public CommentController(ICommentRepository CommentRepo,IStockRepository stockRepo)
        {
            _CommentRepo=CommentRepo;
            _stockRepo=stockRepo;
        }
        [HttpGet]

        public async Task<IActionResult> GetAllComments()
        {
           var Comments= await _CommentRepo.GetAllAsync();
           var CommentDto= Comments.Select(s=>s.ToCommentDto());
           return Ok(CommentDto);

        } 

        [HttpGet("{id}")]

        public async Task<IActionResult>GetCommentById([FromRoute] int id)
        {
            var comment=await _CommentRepo.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        [HttpPost("{stockId}")]

        public async Task<IActionResult>CreateComment([FromRoute] int StockId,CreateCommentRequest createComment)
        {
            if(! await _stockRepo.StockExists(StockId))
            {
                return BadRequest("Stock does not exist");
            }

            var comments=createComment.ToCommentFromCreate(StockId);
            await _CommentRepo.CreateAsync(comments);
            return CreatedAtAction(nameof(GetCommentById),new{id=comments},comments.ToCommentDto());
        }
    }
}