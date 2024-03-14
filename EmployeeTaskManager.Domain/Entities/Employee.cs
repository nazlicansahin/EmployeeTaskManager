
namespace EmployeeTaskManager.Domain.Entities
{
    public class Employee
    {
        public Guid PersonId { get; set; }
        public Guid TaskId { get; set; }
        public Task Task { get; set; }

    }
}