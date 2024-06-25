using System;

namespace BillingAPI.Models
{
    public class BillingLine
    {
        public int Id { get; set; }
        public int BillingId { get; set; }
        public Billing Billing { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
    }
}
