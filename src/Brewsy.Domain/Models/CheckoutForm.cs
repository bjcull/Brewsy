namespace Brewsy.Domain.Models
{
    public class CheckoutForm
    {
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
        public int BeerId { get; set; }
    }
}
