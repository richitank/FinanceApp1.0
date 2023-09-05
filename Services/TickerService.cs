using FinanceProject_WebApp_1_1.Models;
using FinanceProject_WebApp_1_1.Repositories;
using System.Collections.Generic;

namespace FinanceProject_WebApp_1_1.Services
{
    public class TickerService : ITickerService
    {
        private readonly ITickerRepository _tickerRepository;
        public TickerService(ITickerRepository tickerRepository) 
        {
            _tickerRepository = tickerRepository;
        }

        public Tickers GetTickerBySymbol(string symbol)
        {
            return _tickerRepository.GetBySymbol(symbol);
        }

        public IEnumerable<Tickers> GetAllTickers()
        {
            return _tickerRepository.GetAll();
        }
        public void AddTicker(Tickers ticker)
        {
            _tickerRepository.Add(ticker);
        }

        public void UpdateTicker(Tickers tickerObject)
        {
            _tickerRepository.Update(tickerObject);
        }
        public void DeleteTicker(string symbol)
        {
            _tickerRepository.Delete(symbol);
        }

    }
}
