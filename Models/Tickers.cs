using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceProject_WebApp_1_1.Models
{
   
    public class Tickers
    {
        [Key]
        public string Ticker { get; set; }
        public bool Active { get; set; }
        public string Cik { get; set; }
        public string Composite_Figi { get; set; }
        public string Currency_Name { get; set; }
        public DateTime Last_Updated_Utc { get; set; }
        public string Locale { get; set; }
        public string Market { get; set; }
        public string Name { get; set; }
        public string Primary_Exchange { get; set; }
        public string Share_Class_Figi { get; set; }
        public string Type { get; set; }
    }
}
