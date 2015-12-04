using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Data;
using Brewsy.Domain.Models;
using Brewsy.Domain.Services;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Brewsy.Web.Controllers
{
    public class ChargeController : Controller
    {
        private readonly IChargeService _chargeService;
        private readonly BrewsyContext _context;

        public ChargeController(IChargeService chargeService, BrewsyContext context)
        {
            _chargeService = chargeService;
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(CheckoutForm model)
        {
            var beer = _context.Beers.Include(x => x.User).FirstOrDefault(x => x.Id == model.BeerId);

            var purchase = _chargeService.Charge(model, beer);

            return RedirectToAction("Thankyou", "Home");
        }
    }
}
