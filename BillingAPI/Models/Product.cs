﻿namespace BillingAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<BillingLine> BillingLines { get; set; }
    }
}
