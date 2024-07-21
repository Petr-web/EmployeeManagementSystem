namespace EmployeeManagementSystem_.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public DateTime DateOfJoining { get; set; }
        public ICollection<PerformanceRecord> PerformanceRecords { get; set; }
        public ICollection<LeaveApplication> LeaveApplications { get; set; }
    }
}
