using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brewsy.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string StripePaymentId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
