using FinanceProject_WebApp_1_1.Models;
using FinanceProject_WebApp_1_1.Repositories;
using FinanceProject_WebApp_1_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Model;
using PagedList;
using System;
using System.Linq;
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

        [Authorize]
        public async Task<IActionResult> Index(int? page)
        {
            int pageSize = 50;
            int pageNumber = page ?? 1;

            //var url = $"{baseAddress}&limit=500&apiKey={apiKey}";
            //TickerList tickerList =  await client.GetFromJsonAsync<TickerList>(url);

            //IPagedList<Tickers> list = tickerList.Results.ToPagedList(pageNumber, pageSize);
            //IPagedList<Tickers> list =  await _tickerService.GetAllTickers().ToPagedListAsync(pageNumber, pageSize);
            var list = await _tickerService.GetAllTickers();
            return View(list);
        }

        [Authorize]// GET: TickerController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string symbol)
        {
            var ticker = await _tickerService.GetTickerBySymbol(symbol);
            if(ticker == null)
            {
                return NotFound();
            }
            return View(ticker);
        }

        [Authorize]
        [HttpGet]
        // GET: TickerController/Add
        public async Task<IActionResult> Add()
        {
            return View();
        }

        // POST: TickerController/Add
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Tickers model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _tickerService.AddTicker(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    // Handle or log the validation error
                }
                return View();
            }
        }

        // GET: TickerController/Edit/5
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string symbol)
        {
            var existingTicker = await _tickerService.GetTickerBySymbol(symbol);
            return View(existingTicker);
        }

        // POST: TickerController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Tickers model)
        {
            try
            {
                if (ModelState.IsValid) 
                { 
                   await _tickerService.UpdateTicker(model);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: TickerController/Delete/5
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Delete(string symbol)
        {
            Tickers editTicker = new Tickers();
            try
            {
               editTicker = await _tickerService.GetTickerBySymbol(symbol);
            }
            catch
            {
                return NoContent();
            }
            return View(editTicker);
        }

        // POST: TickerController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Tickers tickerToDelete)
        {
            try
            {
                await _tickerService.DeleteTicker(tickerToDelete.Ticker);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
