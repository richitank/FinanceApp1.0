using FinanceProject_WebApp_1_1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Services
{
    public interface ITickerService
    {
        Task<IEnumerable<Tickers>> GetAllTickers();
        Task<Tickers> GetTickerBySymbol(string symbol);
        Task AddTicker(Tickers tickerObject);
        Task UpdateTicker(Tickers tickerObject);
        Task DeleteTicker(string symbol);
    }
}
