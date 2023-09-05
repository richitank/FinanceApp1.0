using FinanceProject_WebApp_1_1.Models;
using System.Collections.Generic;

namespace FinanceProject_WebApp_1_1.Services
{
    public interface ITickerService
    {
        IEnumerable<Tickers> GetAllTickers();
        Tickers GetTickerBySymbol(string symbol);
        void AddTicker(Tickers tickerObject);
        void UpdateTicker(Tickers tickerObject);
        void DeleteTicker(string symbol);
    }
}
