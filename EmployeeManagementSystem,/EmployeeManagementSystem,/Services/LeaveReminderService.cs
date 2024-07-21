namespace EmployeeManagementSystem_.Services;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EmployeeManagementSystem_.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using EmployeeManagementSystem_.Models; // Assuming models are in the Data folder

    public class LeaveReminderService : BackgroundService
    {
        private readonly EmployeeManagementContext _context;
        private readonly NotificationService _notificationService;

        public LeaveReminderService(EmployeeManagementContext context, NotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Fetch leave applications that start tomorrow
                var leaveApplications = await _context.LeaveApplications
                    .Where(l => l.StartDate.Date == DateTime.Today.AddDays(1))
                    .Include(l => l.Employee)
                    .ToListAsync();

                // Send reminders for each leave application
                foreach (var leaveApplication in leaveApplications)
                {
                    await _notificationService.NotifyLeaveReminder(leaveApplication);
                }

                // Wait for 24 hours before checking again
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }

