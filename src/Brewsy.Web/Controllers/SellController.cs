using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Brewsy.Data;
using Brewsy.Web.ViewModels.Sell;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Stripe;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Brewsy.Web.Controllers
{
    [Authorize]
    public class SellController : Controller
    {
        private readonly BrewsyContext _brewsyContext;

        public SellController(BrewsyContext brewsyContext)
        {
            _brewsyContext = brewsyContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new SellIndexVm();
            var user = _brewsyContext.Users.FirstOrDefault(x => x.Id == User.GetUserId());

            if (!string.IsNullOrEmpty(user.StripeUserId))
            {
                model.HasStripeAccount = true;
            }

            return View(model);
        }

        public IActionResult StripeCallback(string code)
        {
            var service = new StripeOAuthTokenService("sk_test_FYvhtg9S58z86Idcktw6JhAg");

            var result = service.Create(new StripeOAuthTokenCreateOptions()
            {
                Code = code,
                GrantType = "authorization_code"
            });

            var user = _brewsyContext.Users.FirstOrDefault(x => x.Id == User.GetUserId());

            user.StripeAccessToken = result.AccessToken;
            user.StripePublishableKey = result.StripePublishableKey;
            user.StripeRefreshToken = result.RefreshToken;
            user.StripeUserId = result.StripeUserId;

            _brewsyContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
