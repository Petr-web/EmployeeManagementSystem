using EmployeeManagementSystem_.Data;
using EmployeeManagementSystem_.Models;
using EmployeeManagementSystem_.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem_.Controllers;
[ApiController]
[Route("api/[controller]")]
public class LeaveApplicationsController : ControllerBase
{
    private readonly EmployeeManagementContext _context;
    private readonly NotificationService _notificationService;

    public LeaveApplicationsController(EmployeeManagementContext context, NotificationService notificationService)
    {
        _context = context;
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaveApplication>>> GetLeaveApplications()
    {
        return await _context.LeaveApplications.Include(l => l.Employee).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveApplication>> GetLeaveApplication(int id)
    {
        var leaveApplication = await _context.LeaveApplications.Include(l => l.Employee).FirstOrDefaultAsync(l => l.Id == id);

        if (leaveApplication == null)
        {
            return NotFound();
        }

        return leaveApplication;
    }

    [HttpPost]
    public async Task<ActionResult<LeaveApplication>> PostLeaveApplication(LeaveApplication leaveApplication)
    {
        _context.LeaveApplications.Add(leaveApplication);
        await _context.SaveChangesAsync();

        // Notify relevant employees
        await _notificationService.NotifyLeaveApproval(leaveApplication);

        return CreatedAtAction(nameof(GetLeaveApplication), new { id = leaveApplication.Id }, leaveApplication);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLeaveApplication(int id, LeaveApplication leaveApplication)
    {
        if (id != leaveApplication.Id)
        {
            return BadRequest();
        }

        _context.Entry(leaveApplication).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LeaveApplicationExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        // Notify relevant employees
        await _notificationService.NotifyLeaveApproval(leaveApplication);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaveApplication(int id)
    {
        var leaveApplication = await _context.LeaveApplications.FindAsync(id);
        if (leaveApplication == null)
        {
            return NotFound();
        }

        _context.LeaveApplications.Remove(leaveApplication);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LeaveApplicationExists(int id)
    {
        return _context.LeaveApplications.Any(e => e.Id == id);
    }
}
