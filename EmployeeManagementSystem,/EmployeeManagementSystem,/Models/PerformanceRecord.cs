namespace EmployeeManagementSystem_.Models
{
    public class PerformanceRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Date { get; set; }
        public string Task { get; set; }
        public int HoursWorked { get; set; }
        public string PerformanceNotes { get; set; }
        public Employee Employee { get; set; }
    }
}
