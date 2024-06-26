using Newtonsoft.Json;

namespace BillingAPI.Models
{
    public class BillingLine
    {
        public int Id { get; set; }
        [JsonProperty("productId")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        [JsonProperty("unit_price")]
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public int BillingId { get; set; }
        public Billing Billing { get; set; }
    }
}
