using FinanceProject_WebApp_1_1.Models;
using FinanceProject_WebApp_1_1.Repositories;
using FinanceProject_WebApp_1_1.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FinanceProject_WebApp_1_1.Controllers
{
    public class TickerController : Controller
    {
        private readonly ITickerService _tickerService;
        public TickerController(ITickerService tickerService)
        {
            _tickerService = tickerService;
        }

        static HttpClient client = new HttpClient();
        string apiKey = "zdwksmamdmJ5FpDzhehD7MY4fuZrHgfl";
        string baseAddress = "https://api.polygon.io/v3/reference/tickers?Active=true";   

        //TODO: This can be improved to dynamically show all the tickerList using next_url feature

        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 50;
            int pageNumber = page ?? 1;

            var url = $"{baseAddress}&limit=500&apiKey={apiKey}";
            TickerList tickerList =  await client.GetFromJsonAsync<TickerList>(url);

            IPagedList<Tickers> list = tickerList.Results.ToPagedList(pageNumber, pageSize);
            return View(list);
        }

        // GET: TickerController/Details/5
        [HttpGet]
        public ActionResult Details(string symbol="AAPL")
        {
            var ticker = _tickerService.GetTickerBySymbol(symbol);
            if(ticker == null)
            {
                return NotFound();
            }
            return View(ticker);
        }

        [HttpGet]
        // GET: TickerController/Add
        public ActionResult Add()
        {
            var newTicker = new Tickers
            {
                Ticker = "TestData3",
                Active = true,
                Name = "Test3",
                Currency_Name = "USD",
                Composite_Figi = "889"
            };

            _tickerService.AddTicker(newTicker);
            return View();
        }

        // POST: TickerController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TickerController/Edit/5
        [HttpGet]
        public ActionResult Edit(string symbol="TestData")
        {
            //TODO: This needs update operation
            var existingTicker = _tickerService.GetTickerBySymbol(symbol);
            if (existingTicker != null)
            {
                existingTicker.Composite_Figi = "64794";
                existingTicker.Active = false;
                existingTicker.Name = "TestDataNew";
                _tickerService.UpdateTicker(existingTicker);
            }
            return View(existingTicker);
        }

        // POST: TickerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TickerController/Delete/5
        [HttpGet]
        public ActionResult Delete(string symbol="TestData3")
        {
            try
            {
                _tickerService.DeleteTicker(symbol);
            }
            catch
            {
                return NoContent();
            }
            return View();
        }

        // POST: TickerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
