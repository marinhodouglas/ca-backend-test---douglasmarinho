using Newtonsoft.Json;


namespace BillingAPI.Models
{
    public class Billing
    {
        public int Id { get; set; }
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [JsonProperty("date")]
        public DateTime Date { get; set; }
        [JsonProperty("due_date")]
        public DateTime DueDate { get; set; }
        [JsonProperty("total_amount")]
        public decimal TotalAmount { get; set; }
        public string Currency { get; set; }
        [JsonProperty("lines")]
        public ICollection<BillingLine> Lines { get; set; }
    }
}
