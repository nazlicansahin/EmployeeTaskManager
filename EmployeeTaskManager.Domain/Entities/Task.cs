using EmployeeTaskManager.Domain.Common;
using EmployeeTaskManager.Domain.Enum;

namespace EmployeeTaskManager.Domain.Entities;

public class Task : EntityBase<Guid>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public TaskState TaskState { get; set; }

    public string? EmployeeId { get; set; }


}