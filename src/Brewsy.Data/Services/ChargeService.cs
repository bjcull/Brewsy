using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Domain.Entities;
using Brewsy.Domain.Models;
using Brewsy.Domain.Services;
using Stripe;

namespace Brewsy.Data.Services
{
    public class ChargeService : IChargeService
    {
        private readonly BrewsyContext _brewsyContext;

        public ChargeService(BrewsyContext brewsyContext)
        {
            _brewsyContext = brewsyContext;
        }

        public Purchase Charge(CheckoutForm form, Beer beer)
        {
            var charge = new StripeChargeCreateOptions()
            {
                Amount = Convert.ToInt32(beer.Price * 100),
                ApplicationFee = Convert.ToInt32((beer.Price * 0.05M) * 100),
                Currency = "AUD",
                Source = new StripeSourceOptions()
                {
                    TokenId = form.StripeToken
                }
            };

            var service = new StripeChargeService(beer.User.StripeAccessToken);
            var result = service.Create(charge);

            if (!result.Paid)
            {
                throw new Exception(result.FailureMessage);
            }

            var purchase = new Purchase()
            {
                Email = form.StripeEmail,
                StripePaymentId = result.Id,
                CreatedDate = DateTime.Now
            };

            _brewsyContext.Purchases.Add(purchase);
            _brewsyContext.SaveChanges();

            return purchase;
        }
    }
}
