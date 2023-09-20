using AutoMapper;
using FinanceProject_WebApp_1_1.DbContexts;
using FinanceProject_WebApp_1_1.Models;
using Microsoft.CodeAnalysis.Elfie.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public async Task<Tickers> GetBySymbol(string symbol)
        {
            return await _db.Tickers.FirstOrDefaultAsync(t => t.Ticker == symbol);
        }

        public async Task<IEnumerable<Tickers>> GetAll()
        {
            return await _db.Tickers.ToListAsync();
        }
        public async Task Add(Tickers ticker)
        {
            await _db.Tickers.AddAsync(ticker);
            await _db.SaveChangesAsync();
        }

        public async Task AddAll(IEnumerable<Tickers> tickers)
        {
            await _db.Tickers.AddRangeAsync(tickers);
            await _db.SaveChangesAsync();
        }


        public async Task Update(Tickers tickerObject)
        {
            var existingTicker = await _db.Tickers.FirstOrDefaultAsync(t => t.Ticker == tickerObject.Ticker);
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
                //TODO: check difference between update and exceute async
                _db.Tickers.Update(existingTicker);
                await _db.SaveChangesAsync();
            }
            else //For new Ticker
            {
                await Add(tickerObject);
            }
        }

        public async Task UpdateAll(IEnumerable<Tickers> tickerObjects)
        {
            _db.Tickers.UpdateRange(tickerObjects);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(string symbol)
        {
            var tickerToDelete = await _db.Tickers.FirstOrDefaultAsync(t => t.Ticker == symbol);
            if (tickerToDelete != null)
            {
                //TODO: check difference between remove and executedelete async
                _db.Tickers.Remove(tickerToDelete);
                await _db.SaveChangesAsync();
            }
        }

    }
}
