using System;
using System.Collections.Generic;

namespace BillingAPI.Models
{
    public class Billing
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        public ICollection<BillingLine> BillingLines { get; set; }
    }
}
