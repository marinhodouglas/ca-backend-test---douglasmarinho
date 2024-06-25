using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BillingAPI.Data;
using BillingAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class BillingLinesController : ControllerBase
{
    private readonly BillingContext _context;

    public BillingLinesController(BillingContext context)
    {
        _context = context;
    }

    // GET: api/BillingLines
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BillingLine>>> GetBillingLine()
    {
        return await _context.BillingLines.Include(bl => bl.Product).ToListAsync();
    }

    // GET: api/BillingLines/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BillingLine>> GetBillingLine(int id)
    {
        var billingLine = await _context.BillingLines.Include(bl => bl.Product).FirstOrDefaultAsync(bl => bl.Id == id);

        if (billingLine == null)
        {
            return NotFound();
        }

        return billingLine;
    }

    // PUT: api/BillingLines/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutBillingLine(int id, BillingLine billingLine)
    {
        if (id != billingLine.Id)
        {
            return BadRequest();
        }

        _context.Entry(billingLine).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BillingLineExists(id))
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

    // POST: api/BillingLines
    [HttpPost]
    public async Task<ActionResult<BillingLine>> PostBillingLine(BillingLine billingLine)
    {
        _context.BillingLines.Add(billingLine);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBillingLine", new { id = billingLine.Id }, billingLine);
    }

    // DELETE: api/BillingLines/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBillingLine(int id)
    {
        var billingLine = await _context.BillingLines.FindAsync(id);
        if (billingLine == null)
        {
            return NotFound();
        }

        _context.BillingLines.Remove(billingLine);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BillingLineExists(int id)
    {
        return _context.BillingLines.Any(e => e.Id == id);
    }
}
