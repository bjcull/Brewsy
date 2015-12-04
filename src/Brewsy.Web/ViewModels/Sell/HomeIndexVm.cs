using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Domain.Entities;

namespace Brewsy.Web.ViewModels.Sell
{
    public class HomeIndexVm
    {
        public List<Beer> Beers { get; set; }

        public HomeIndexVm()
        {
            Beers = new List<Beer>();
        }
    }
}
