using FinShark.Dtos.Stock;
using FinShark.Helpers;
using FinShark.Models;

namespace FinShark.Interfaces
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync(QueryObject query);
        public Task<Stock?> GetByIdAsync(int id);
        public Task<Stock> CreateAsync(Stock stockModel);
        public Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        public Task<Stock?> DeleteAsync(int id);
        public Task<bool> StockExists(int stockId);
    }
}
