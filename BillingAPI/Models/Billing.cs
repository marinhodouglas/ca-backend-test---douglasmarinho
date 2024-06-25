using System;

namespace BillingAPI.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public DateTime Date { get; set; }
        public ICollection<BillingLine> BillingLines { get; set; }
    }
}
