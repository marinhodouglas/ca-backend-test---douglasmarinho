using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BillingAPI.Data;
using BillingAPI.Models;

namespace BillingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingImportController : ControllerBase
    {
        private readonly BillingContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public BillingImportController(BillingContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportBilling()
        {
            try
            {
                // Simulação de consulta à API externa para obter dados de billing
                var billingApiUrl = "https://65c3b12439055e7482c16bca.mockapi.io/api/v1/billing";
                var httpClient = _httpClientFactory.CreateClient();
                var response = await httpClient.GetAsync(billingApiUrl);

                if (!response.IsSuccessStatusCode)
                {
                    return StatusCode((int)response.StatusCode, "Erro ao acessar API externa de billing.");
                }

                // Deserializa o conteúdo da resposta HTTP para o objeto Billing
                var billingData = await response.Content.ReadFromJsonAsync<Billing>();

                // Verifica se o cliente já existe no banco local
                var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == billingData.Customer.Id);
                if (existingCustomer == null)
                {
                    return BadRequest("O cliente não está cadastrado localmente.");
                }

                // Verifica se os produtos existem no banco local
                var existingProducts = await _context.Products.Where(p => billingData.Lines.Any(bl => bl.ProductId == p.Id)).ToListAsync();
                if (existingProducts.Count != billingData.Lines.Count)
                {
                    return BadRequest("Alguns produtos não estão cadastrados localmente.");
                }

                // Cria a fatura no banco local
                var newBilling = new Billing
                {
                    InvoiceNumber = billingData.InvoiceNumber,
                    CustomerId = existingCustomer.Id, // Associa o cliente existente
                    Date = billingData.Date,
                    DueDate = billingData.DueDate,
                    TotalAmount = billingData.TotalAmount,
                    Currency = billingData.Currency
                };

                _context.Billings.Add(newBilling);
                await _context.SaveChangesAsync();

                // Cria as linhas de fatura no banco local
                foreach (var line in billingData.Lines)
                {
                    var existingProduct = existingProducts.FirstOrDefault(p => p.Id == line.ProductId);
                    if (existingProduct == null)
                    {
                        // Isso não deveria acontecer, pois já verificamos a existência dos produtos acima
                        return BadRequest("Produto não encontrado localmente.");
                    }

                    var newBillingLine = new BillingLine
                    {
                        BillingId = newBilling.Id,
                        ProductId = existingProduct.Id,
                        Description = line.Description,
                        Quantity = line.Quantity,
                        UnitPrice = line.UnitPrice,
                        Subtotal = line.Subtotal
                    };

                    _context.BillingLines.Add(newBillingLine);
                }

                await _context.SaveChangesAsync();

                return Ok("Dados de billing importados com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao importar dados de billing5: {ex.Message}");
            }
        }
    }
}
