using FinanceProject_WebApp_1_1.Models;
using FinanceProject_WebApp_1_1.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Services
{
    public class TickerService : ITickerService
    {
        private readonly ITickerRepository _tickerRepository;
        public TickerService(ITickerRepository tickerRepository) 
        {
            _tickerRepository = tickerRepository;
        }

        public async Task<Tickers> GetTickerBySymbol(string symbol)
        {
            return await _tickerRepository.GetBySymbol(symbol);
        }

        public async Task<IEnumerable<Tickers>> GetAllTickers()
        {
            return await _tickerRepository.GetAll();
        }
        public async Task AddTicker(Tickers ticker)
        {
            await _tickerRepository.Add(ticker);
        }
        public async Task AddAll(IEnumerable<Tickers> tickerObjects)
        {
            await _tickerRepository.AddAll(tickerObjects);
        }
        public async Task UpdateTicker(Tickers tickerObject)
        {
            await _tickerRepository.Update(tickerObject);
        }
        public async Task UpdateAll(IEnumerable<Tickers> tickerObjects)
        {
            await _tickerRepository.UpdateAll(tickerObjects);
        }
        public async Task DeleteTicker(string symbol)
        {
            await _tickerRepository.Delete(symbol);
        }

    }
}
