using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.Data;
using demo.DTOs.stock;
using demo.interfaces;
using demo.models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace demo.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDB_Context _Context;
        public StockRepository(ApplicationDB_Context context)
        {
            _Context=context;
        }
        public Task<List<Stocks>> GetAllAsync()
        {
            return _Context.stocks.Include(c=>c.Comments).ToListAsync();
        }

        public async Task<Stocks?> FirstOrDefaultAsync(int id )
        {
            return await _Context.stocks.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Stocks> AddStocks(Stocks stocks)
        {
           await _Context.stocks.AddAsync(stocks);
           await _Context.SaveChangesAsync();
           return stocks;
        }

        public async Task<Stocks?> UpdateStockDb(UpdateStockRequestDto update,int id)
        {
           var stockDto= await FirstOrDefaultAsync(id);
            if (stockDto == null)
            {
                return null;
            }
            stockDto.CompanyName=update.CompanyName;
            stockDto.Industry=update.Industry;
            stockDto.LastDiv=update.LastDiv;
            stockDto.Purchase=update.Purchase;
            stockDto.Symbol=update.Symbol;
            stockDto.MarketCap=update.MarketCap;
            await _Context.SaveChangesAsync();

           return stockDto;
        }

        public async Task<Stocks?>Delete(int id)
        {
            var deleteStock=await FirstOrDefaultAsync(id);
            if (deleteStock == null)
            {
                return null;
            }
            _Context.stocks.Remove(deleteStock);
            _Context.SaveChanges();
            return deleteStock;
        }

        public Task<bool> StockExists(int id)
        {
            return _Context.stocks.AnyAsync(s=>s.Id==id);
        }
    }
}