using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Data;
using demo.DTOs.stock;
using demo.interfaces;
using demo.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.contollers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDB_Context _Context; 
        private readonly IStockRepository _stockRepo;
        public StockController(ApplicationDB_Context context,IStockRepository StockRepo)
        {
            _Context=context;
            _stockRepo=StockRepo;
        }
        [HttpGet]
        public async Task< IActionResult> GetAll()
        {
            var Stocks= await _stockRepo.GetAllAsync();
          var DtoStocks=  Stocks.Select(s=>s.ToStockDto())
            ;
            return Ok(DtoStocks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getById( [FromRoute] int id)
        {
            var stock= await _Context.stocks.Include(c=>c.Comments).FirstOrDefaultAsync(i=>i.Id==id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public async Task< IActionResult> create([FromBody] CreateStockRequestDto createStockRequest)
        {
           var stockModel= createStockRequest.ToStockFromCreateDTO();
          await _stockRepo.AddStocks(stockModel);
           return CreatedAtAction(nameof(GetAll),new{id=stockModel.Id},stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]

        public async Task< IActionResult> Update([FromRoute] int id,[FromBody] UpdateStockRequestDto updateStock)
        {
            var stockModel= await _stockRepo.UpdateStockDb(updateStock,id);
            if (stockModel == null)
            {
                return NotFound();
            }
            

          
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete]
        [Route("{id}")]

        public async Task< IActionResult> Delete([FromRoute] int id)
        {
            var stockModel=await _stockRepo.Delete(id);
            if (stockModel == null)
            {
                return NotFound();
            }
           
            return NoContent();
        }
    }
}