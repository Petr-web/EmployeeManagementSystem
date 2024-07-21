using EmployeeManagementSystem_.Hubs;
using EmployeeManagementSystem_.Models;
using Microsoft.AspNetCore.SignalR;

namespace EmployeeManagementSystem_.Services
{
    public class NotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task NotifyLeaveApproval(LeaveApplication leaveApplication)
        {
            var message = $"Leave approved for {leaveApplication.Employee.Name} from {leaveApplication.StartDate.ToShortDateString()} to {leaveApplication.EndDate.ToShortDateString()}";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }

        public async Task NotifyLeaveReminder(LeaveApplication leaveApplication)
        {
            var message = $"Reminder: Leave for {leaveApplication.Employee.Name} starts on {leaveApplication.StartDate.ToShortDateString()}";
            await _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
        }
    }
}

