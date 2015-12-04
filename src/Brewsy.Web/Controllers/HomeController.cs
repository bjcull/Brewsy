using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Data;
using Brewsy.Web.ViewModels.Sell;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

namespace Brewsy.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly BrewsyContext _context;

        public HomeController(BrewsyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new HomeIndexVm();

            model.Beers = _context.Beers.Include(x => x.User).Where(x => x.User != null).ToList();

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Thankyou()
        {
            return View();
        }
    }
}
