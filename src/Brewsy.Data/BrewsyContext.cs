using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brewsy.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Brewsy.Data
{
    public class BrewsyContext : IdentityDbContext<User>
    {
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Beer> Beers { get; set; }
    }
}
