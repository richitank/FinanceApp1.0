using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Models
{
    public class TickerList
    {
        public int Count { get; set; }
        public string Next_Url { get; set; }
        public string Request_Id { get; set; }
        public List<Tickers> Results { get; set; }
        public string Status { get; set; }
    }
}



