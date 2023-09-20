using FinanceProject_WebApp_1_1.Models;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Repositories
{
    public interface ITickerRepository
    {
        Task<IEnumerable<Tickers>> GetAll();
        Task<Tickers> GetBySymbol(string symbol);
        Task Add(Tickers ticker);
        Task Update(Tickers ticker);   
        Task Delete(string symbol);
        Task AddAll(IEnumerable<Tickers> tickers);
        Task UpdateAll(IEnumerable<Tickers> tickers);

    }
}
