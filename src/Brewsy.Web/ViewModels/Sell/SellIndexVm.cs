using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Domain.Entities;

namespace Brewsy.Web.ViewModels.Sell
{
    public class SellIndexVm
    {
        public bool HasStripeAccount { get; set; }
        public List<Beer> Beers { get; set; }

        public SellIndexVm()
        {
            Beers = new List<Beer>();
        }
    }
}
