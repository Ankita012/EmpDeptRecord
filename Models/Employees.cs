namespace Employee.Models
{
    public class Employees
    {
        public int EmployeeId { get; set; }
        public string? EmployeeName { get; set; }
        public string? Department { get; set; }
        public DateOnly DateOfJoining { get; set; }
        public string? PhotoFileName { get; set; }

    }
}
