using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using demo.DTOs.stock;
using demo.models;

namespace demo.interfaces
{
    public interface IStockRepository
    {
        Task<List<Stocks>> GetAllAsync();
        Task<Stocks?> FirstOrDefaultAsync(int id );
        Task<Stocks?> UpdateStockDb(UpdateStockRequestDto update,int id);
        Task<Stocks?>Delete(int id);
        Task<Stocks> AddStocks(Stocks stocks);
        Task<bool> StockExists(int id);
    }
}