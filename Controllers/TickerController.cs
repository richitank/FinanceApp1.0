using FinanceProject_WebApp_1_1.Models;
using FinanceProject_WebApp_1_1.Repositories;
using FinanceProject_WebApp_1_1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.CodeAnalysis.Elfie.Model;
using PagedList;
using System;
using System.Collections.Generic;
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
            var tickers = new List<Tickers>();

            var url = $"{baseAddress}&limit=5&apiKey={apiKey}";
            try
            {
                TickerList tickerList = await client.GetFromJsonAsync<TickerList>(url);
                if (tickerList.Results.Count > 0)
                {
                    //TODO: improve this solution.
                    await _tickerService.UpdateAll(tickerList.Results);
                }
                var list = await _tickerService.GetAllTickers();
                return View(list);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured while trying to call API and update DB: {e.Message}");
                return NoContent();
            }
            
            //IPagedList<Tickers> list = tickerList.Results.ToPagedList(pageNumber, pageSize);
            //IPagedList<Tickers> list =  await _tickerService.GetAllTickers().ToPagedListAsync(pageNumber, pageSize);
            
        }

        [Authorize]// GET: TickerController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(string symbol)
        {
            try
            {
                var ticker = await _tickerService.GetTickerBySymbol(symbol);
                if (ticker == null)
                {
                    return NotFound();
                }
                return View(ticker);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured in Details, while trying to GetTickerBySymbol: {e.Message}");
                return NoContent();
            }    
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
            catch (Exception e)
            {
                Console.WriteLine($"Error occured while adding a new Ticker: {e.Message}");
                return View();
            }
        }

        // GET: TickerController/Edit/5
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(string symbol)
        {
            try
            {
                var existingTicker = await _tickerService.GetTickerBySymbol(symbol);
                return View(existingTicker);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error occured in Edit, while trying to GetTickerBySymbol: {e.Message}");
                return NoContent();
            }
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
                Console.WriteLine($"Error occured while updating Ticker after Edit: {e.Message}");
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
            catch(Exception e)
            {
                Console.WriteLine($"Error occured in Delete, while trying to GetTickerBySymbol: {e.Message}");
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
            catch (Exception e)
            {
                Console.WriteLine($"Error occured while trying to Delete a Ticker: {e.Message}");
                return View();
            }
        }
    }
}
