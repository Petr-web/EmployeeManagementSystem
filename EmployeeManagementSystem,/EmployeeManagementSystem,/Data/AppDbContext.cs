namespace EmployeeManagementSystem_.Data;
using EmployeeManagementSystem_.Models;
using Microsoft.EntityFrameworkCore;

public class EmployeeManagementContext : DbContext
{
    public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
        : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<LeaveApplication> LeaveApplications { get; set; }
    public DbSet<PerformanceRecord> PerformanceRecords { get; set; }
}

