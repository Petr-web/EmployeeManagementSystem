using EmployeeManagementSystem_.Data;
using EmployeeManagementSystem_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem_.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PerformanceRecordsController : ControllerBase
{
    private readonly EmployeeManagementContext _context;

    public PerformanceRecordsController(EmployeeManagementContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PerformanceRecord>>> GetPerformanceRecords()
    {
        return await _context.PerformanceRecords.Include(p => p.Employee).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PerformanceRecord>> GetPerformanceRecord(int id)
    {
        var performanceRecord = await _context.PerformanceRecords.Include(p => p.Employee).FirstOrDefaultAsync(p => p.Id == id);

        if (performanceRecord == null)
        {
            return NotFound();
        }

        return performanceRecord;
    }

    [HttpPost]
    public async Task<ActionResult<PerformanceRecord>> PostPerformanceRecord(PerformanceRecord performanceRecord)
    {
        _context.PerformanceRecords.Add(performanceRecord);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPerformanceRecord), new { id = performanceRecord.Id }, performanceRecord);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPerformanceRecord(int id, PerformanceRecord performanceRecord)
    {
        if (id != performanceRecord.Id)
        {
            return BadRequest();
        }

        _context.Entry(performanceRecord).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PerformanceRecordExists(id))
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
    public async Task<IActionResult> DeletePerformanceRecord(int id)
    {
        var performanceRecord = await _context.PerformanceRecords.FindAsync(id);
        if (performanceRecord == null)
        {
            return NotFound();
        }

        _context.PerformanceRecords.Remove(performanceRecord);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PerformanceRecordExists(int id)
    {
        return _context.PerformanceRecords.Any(e => e.Id == id);
    }
}
