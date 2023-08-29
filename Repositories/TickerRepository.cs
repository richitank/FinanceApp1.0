using AutoMapper;
using FinanceProject_WebApp_1_1.DbContexts;
using FinanceProject_WebApp_1_1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Repositories
{
    public class TickerRepository: ITickerRepository
    {
        private readonly FinanceDBContext _db;
        private IMapper _mapper;

        public TickerRepository(FinanceDBContext db /*, IMapper mapper*/)
        {
            _db = db;
           /* _mapper = mapper;*/
        }

        public Task<bool> DeleteTickerData(string symbol)
        {
            throw new System.NotImplementedException();
        }

        public Task<Tickers> GetTickerBySymbol(string symbol)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Tickers>> GetTickers()
        {
            throw new System.NotImplementedException();
        }

        public Task<Tickers> UpdateTickerData(Tickers ticker)
        {
            throw new System.NotImplementedException();
        }
    }
}
