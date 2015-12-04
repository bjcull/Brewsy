using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Brewsy.Domain.Entities
{
    public class User : IdentityUser
    {
        public string StripeUserId { get; set; }
        public string StripePublishableKey { get; set; }
        public string StripeAccessToken { get; set; }
        public string StripeRefreshToken { get; set; }

    }
}
