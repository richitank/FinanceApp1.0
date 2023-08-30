using FinanceProject_WebApp_1_1.Models;
using System.Collections.Generic;

namespace FinanceProject_WebApp_1_1.Services
{
    public interface ITickerService
    {
        IEnumerable<Tickers> GetAllTickers();
        Tickers GetTickerBySymbol(string symbol);
        void AddTicker(Tickers ticker);
        void UpdateTicker(Tickers ticker);
        void DeleteTicker(string symbol);
    }
}
