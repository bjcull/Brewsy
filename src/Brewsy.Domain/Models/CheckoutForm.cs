namespace Brewsy.Domain.Models
{
    public class CheckoutForm
    {
        public string StripeToken { get; set; }
        public string StripeEmail { get; set; }
    }
}
