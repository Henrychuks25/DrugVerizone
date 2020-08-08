using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DrugVerizone.Models;
using Microsoft.AspNetCore.Authorization;
using DrugVerizone.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace DrugVerizone.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DrugVerifyContext _context;

        public HomeController(ILogger<HomeController> logger, DrugVerifyContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Search(string searchString)
        {
            if (ModelState.IsValid)
            {
                var result = from m in _context.Drugs
                         select m;


                    if (!String.IsNullOrEmpty(searchString))
                    {
                        result = result.Where(s => s.UniqueCode.Contains(searchString));
                        await result.ToListAsync();
                      //  return RedirectToAction("Search", "Home");
                        return View(await result.ToListAsync());
                    }

                  
                    else
                    {
                        return Redirect("Index");
                    }
            }
           

            return View();
        }

        public IActionResult Complaint()
        {
            return View();
        }

        public IActionResult Dashboard()
        {

            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
