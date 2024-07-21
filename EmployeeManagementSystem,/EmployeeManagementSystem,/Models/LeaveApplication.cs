namespace EmployeeManagementSystem_.Models
{
    public class LeaveApplication
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public Employee Employee { get; set; }
    }
}