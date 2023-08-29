using FinanceProject_WebApp_1_1.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Repositories
{
    public interface ITickerRepository
    {
        Task<IEnumerable<Tickers>> GetTickers();
        Task<Tickers> GetTickerBySymbol(string symbol);
        Task<Tickers> UpdateTickerData(Tickers ticker);   
        Task<bool> DeleteTickerData(string symbol);


      /*  Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);*/
    }
}
