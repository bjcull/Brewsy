using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Domain.Entities;
using Brewsy.Domain.Models;

namespace Brewsy.Domain.Services
{
    public interface IChargeService
    {
        Purchase Charge(CheckoutForm form, Beer beer);
    }
}
