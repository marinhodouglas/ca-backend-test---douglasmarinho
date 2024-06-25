using BillingAPI.Data;
using BillingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class BillingController : ControllerBase
{
    private readonly BillingContext _context;

    public BillingController(BillingContext context)
    {
        _context = context;
    }

    //GET: api/Billings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Billing>>> GetBillings()
    {
        return await _context.Billings.Include(b => b.BillingLines).ThenInclude(bl => bl.Product).ToListAsync();
    }

    //GET: api/Billings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Billing>> GetBilling(int id)
    {
        var billing = await _context.Billings.Include(b => b.BillingLines).ThenInclude(bl => bl.Product).FirstOrDefaultAsync(b => b.Id == id);

        if (billing == null)
        {
            return NotFound();
        }

        return billing;
    }

    //PUT: api/Billings/5
    [HttpPut("{Id}")]
    public async Task<ActionResult> PutBilling(int id, Billing billing)
    {
        if (id != billing.Id)
        {
            return BadRequest();
        }
        _context.Entry(billing).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

            if (!BillingExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    //POST: api/Billings
    [HttpPost]
    public async Task<ActionResult<Billing>> PostBilling(Billing billing)
    {
        _context.Billings.Add(billing);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBilling", new { id = billing.Id }, billing);
    }

    //DELETE : api/Billings
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBilling(int id)
    {
        var billing = await _context.Billings.FindAsync(id);

        if (billing == null)
        {
            return NotFound();
        }
        _context.Billings.Remove(billing);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BillingExists(int id)
    {
        return _context.Products.Any(e => e.Id == id);
    }
}

