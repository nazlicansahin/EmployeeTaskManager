using MongoDB.Bson;
using EmployeeTaskManager.API.Repositories.Models;
using EmployeeTaskManager.API.Repositories.Models.TaskModels;
using EmployeeTaskManager.Domain.Entities;
using EmployeeTaskManager.Domain.Enum;

namespace EmployeeTaskManager.API.Repositories
{
    public interface IEmployeeTaskRepository
    {
        Task<ObjectId> Create(EmployeeTask employeeTask);
        Task<EmployeeTask> Get(ObjectId objectId);
        Task<IEnumerable<EmployeeTask>> GetAll();
        Task<IEnumerable<EmployeeTask>> GetByName(string name);

        Task<IEnumerable<EmployeeTask>> GetByTaskState(TaskState taskState);

        Task<bool> Update(ObjectId objectId, EmployeeTask employeeTask);

        Task<bool> Delete(ObjectId objectId);



    }
}
