using AutoMapper;
using FinanceProject_WebApp_1_1.DbContexts;
using FinanceProject_WebApp_1_1.Models;
using Microsoft.CodeAnalysis.Elfie.Model;
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
            return _db.Tickers.FirstOrDefault(t => t.Ticker == symbol);
        }

        public IEnumerable<Tickers> GetAll()
        {
            return _db.Tickers.ToList();
        }
        public void Add(Tickers ticker)
        {
            _db.Tickers.Add(ticker);
            _db.SaveChanges();
        }

        public void Update(Tickers tickerObject)
        {
            var existingTicker = _db.Tickers.FirstOrDefault(t => t.Ticker == tickerObject.Ticker);
            if (existingTicker != null)
            {
                existingTicker.Composite_Figi = tickerObject.Composite_Figi;
                existingTicker.Active = tickerObject.Active;
                existingTicker.Currency_Name = tickerObject.Currency_Name;
                existingTicker.Cik = tickerObject.Cik;
                existingTicker.Market = tickerObject.Market;
                existingTicker.Locale = tickerObject.Locale;
                existingTicker.Last_Updated_Utc = tickerObject.Last_Updated_Utc;
                existingTicker.Share_Class_Figi = tickerObject.Share_Class_Figi;
                existingTicker.Name = tickerObject.Name;
                existingTicker.Primary_Exchange = tickerObject.Primary_Exchange;
                existingTicker.Type = tickerObject.Type;
                _db.Tickers.Update(existingTicker);
                _db.SaveChanges();
            }        
        }

        public void Delete(string symbol)
        {
            var tickerToDelete = _db.Tickers.FirstOrDefault(t => t.Ticker == symbol);
            if (tickerToDelete != null)
            {
                _db.Tickers.Remove(tickerToDelete);
                _db.SaveChanges();
            }
        }

    }
}
