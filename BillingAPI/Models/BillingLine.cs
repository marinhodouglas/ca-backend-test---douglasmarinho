using System;

namespace BillingAPI.Models
{
    public class BillingLine
    {
        public int Id { get; set; }
        public int BillingId { get; set; }
        public Billing billing { get; set; }
        public int ProductId { get; set; } 
        public Product product { get; set; }    
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
