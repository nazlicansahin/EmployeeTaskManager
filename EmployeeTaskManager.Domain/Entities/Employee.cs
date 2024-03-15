
namespace EmployeeTaskManager.Domain.Entities
{
    public class Employee
    {
        public Guid PersonId { get; set; }
        public Guid TaskId { get; set; }
        public EmployeeTask Task { get; set; }

    }
}