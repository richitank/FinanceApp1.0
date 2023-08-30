using AutoMapper;
using FinanceProject_WebApp_1_1.DbContexts;
using FinanceProject_WebApp_1_1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Repositories
{
    public class TickerRepository: ITickerRepository
    {
        private readonly FinanceDBContext _db;
        private readonly List<Tickers> _tickers = new List<Tickers>();
        //private IMapper _mapper;

        public TickerRepository(FinanceDBContext db /*, IMapper mapper*/)
        {
            _db = db;
           //_mapper = mapper;
        }
        public Tickers GetBySymbol(string symbol)
        {
            return _tickers.FirstOrDefault(p => p.Ticker == symbol);
        }

        public IEnumerable<Tickers> GetAll()
        {
            return _tickers;
        }
        public void Add(Tickers ticker)
        {
            _tickers.Add(ticker);
        }

        public void Update(Tickers ticker)
        {
            var existingTicker = _tickers.FirstOrDefault(p => p.Ticker == ticker.Ticker);
            if (existingTicker != null)
            {
                //existingTicker = ticker;
                existingTicker.Ticker = ticker.Ticker;
                existingTicker.Cik = ticker.Cik;
                existingTicker.Market = ticker.Market;
                existingTicker.Share_Class_Figi =  ticker.Share_Class_Figi;
                existingTicker.Composite_Figi = ticker.Composite_Figi;
                existingTicker.Active = ticker.Active;
                existingTicker.Currency_Name = ticker.Currency_Name;
                existingTicker.Last_Updated_Utc = ticker.Last_Updated_Utc;
                existingTicker.Locale = ticker.Locale;
                existingTicker.Market = ticker.Market;
                existingTicker.Name = ticker.Name;
                existingTicker.Primary_Exchange = ticker.Primary_Exchange;
                existingTicker.Type = ticker.Type;
            }
        }

        public void Delete(string symbol)
        {
            var tickerToDelete = _tickers.FirstOrDefault(p => p.Ticker == symbol);
            if (tickerToDelete != null)
            {
                _tickers.Remove(tickerToDelete);
            }
        }

    }
}
