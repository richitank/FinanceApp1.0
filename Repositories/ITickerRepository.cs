using FinanceProject_WebApp_1_1.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Repositories
{
    public interface ITickerRepository
    {
        IEnumerable<Tickers> GetAll();
        Tickers GetBySymbol(string symbol);
        void Add(Tickers ticker);
        void Update(Tickers ticker);   
        void Delete(string symbol);


      /*  Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);*/
    }
}
