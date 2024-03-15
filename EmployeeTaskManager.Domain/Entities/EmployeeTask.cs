using EmployeeTaskManager.Domain.Common;
using EmployeeTaskManager.Domain.Enum;
using MongoDB.Bson;

namespace EmployeeTaskManager.Domain.Entities;

public class EmployeeTask : EntityBase<ObjectId>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public TaskState TaskState { get; set; }

    public string? EmployeeId { get; set; }


}