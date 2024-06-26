using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillingAPI.Models;
using BillingAPI.Data;

[Route("api/[controller]")]
[ApiController]
public class BillingsController : ControllerBase
{
    private readonly BillingContext _context;

    public BillingsController(BillingContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Billing>>> GetBillings()
    {
        return await _context.Billings.Include(b => b.Lines).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Billing>> GetBilling(int id)
    {
        var billing = await _context.Billings.Include(b => b.Lines).FirstOrDefaultAsync(b => b.Id == id);
        if (billing == null)
        {
            return NotFound();
        }
        return billing;
    }

    [HttpPost]
    public async Task<ActionResult<Billing>> PostBilling(Billing billing)
    {
        _context.Billings.Add(billing);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBilling), new { id = billing.Id }, billing);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBilling(int id, Billing billing)
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
        return _context.Billings.Any(e => e.Id == id);
    }
}

