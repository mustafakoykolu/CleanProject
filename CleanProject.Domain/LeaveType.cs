using CleanProject.Domain.Common;

namespace CleanProject.Domain;

public class LeaveType:BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; } 
}
