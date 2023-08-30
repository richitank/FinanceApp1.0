using FinanceProject_WebApp_1_1.Models;
using FinanceProject_WebApp_1_1.Repositories;
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
        private readonly ITickerRepository _tickerRepository;
        public TickerController(ITickerRepository tickerRepository)
        {
            _tickerRepository = tickerRepository;
        }


        static HttpClient client = new HttpClient();
        string apiKey = "zdwksmamdmJ5FpDzhehD7MY4fuZrHgfl";
        string baseAddress = "https://api.polygon.io/v3/reference/tickerList?Active=true";   

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TickerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TickerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
        public ActionResult Edit(int id)
        {
            return View();
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
        public ActionResult Delete(int id)
        {
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
