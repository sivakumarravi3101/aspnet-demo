using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.DTOs.stock;
using demo.models;

namespace demo.Mappers
{
    public static class StockMapper
    {
        public static stockDto ToStockDto(this Stocks stockModel)
        {
            return new stockDto
            {
                Id=stockModel.Id,
                Symbol=stockModel.Symbol,
                CompanyName=stockModel.CompanyName,
                LastDiv=stockModel.LastDiv,
                Purchase=stockModel.Purchase,
                Industry=stockModel.Industry,
                MarketCap=stockModel.MarketCap,
                comments=stockModel.Comments.Select(x=>x.ToCommentDto()).ToList(),

            };
        }
        public static Stocks ToStockFromCreateDTO(this CreateStockRequestDto createStock)
        {
            return new Stocks
            {
                Symbol=createStock.Symbol,
                CompanyName=createStock.CompanyName,
                LastDiv=createStock.LastDiv,
                Purchase=createStock.Purchase,
                Industry=createStock.Industry,
                MarketCap=createStock.MarketCap,
            };
        }
    }
}