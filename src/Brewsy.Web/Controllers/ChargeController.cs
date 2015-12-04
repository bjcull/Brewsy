using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Domain.Models;
using Brewsy.Domain.Services;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Brewsy.Web.Controllers
{
    public class ChargeController : Controller
    {
        private readonly IChargeService _chargeService;

        public ChargeController(IChargeService chargeService)
        {
            _chargeService = chargeService;
        }

        [HttpPost]
        public IActionResult Index(CheckoutForm model)
        {
            var purchase = _chargeService.Charge(model);

            return RedirectToAction("Thankyou", "Home");
        }
    }
}
