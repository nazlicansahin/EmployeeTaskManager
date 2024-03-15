using EmployeeTaskManager.API.Repositories.Models.TaskModels;
using EmployeeTaskManager.Domain.Entities;
using EmployeeTaskManager.Domain.Enum;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Xml.Linq;

namespace EmployeeTaskManager.API.Repositories
{
    public class EmployeeTaskRepository : IEmployeeTaskRepository
    {
        private readonly IMongoCollection<EmployeeTask> _employeeTasks;
        public EmployeeTaskRepository(IMongoClient client)
        {
            var database = client.GetDatabase("EmployeeTaskManagerDb");
            var collection = database.GetCollection<EmployeeTask>(nameof(EmployeeTask));
            _employeeTasks = collection;
        }

        public async Task<ObjectId> Create(EmployeeTask employeeTask)
        {
            await _employeeTasks.InsertOneAsync(employeeTask);
            return employeeTask.Id;
        }

        public async Task<bool> Delete(ObjectId objectId)
        {
            var filter = Builders<EmployeeTask>.Filter.Eq(x => x.Id, objectId);
            var result = await _employeeTasks.DeleteOneAsync(filter);
            return result.DeletedCount == 1;
        }

        public Task<EmployeeTask> Get(ObjectId objectId)
        {
            var filter = Builders<EmployeeTask>.Filter.Eq(x => x.Id, objectId);
            var task = _employeeTasks.Find(filter).FirstOrDefaultAsync();
            return task;
        }

        public async Task<IEnumerable<EmployeeTask>> GetAll()
        {
            var tasks = await _employeeTasks.Find(_ => true).ToListAsync();
            return tasks;
        }

        public async Task<IEnumerable<EmployeeTask>> GetByName(string name)
        {
            var filter = Builders<EmployeeTask>.Filter.Eq<string>(x => x.Name, name);
            var tasks = await _employeeTasks.Find(filter).ToListAsync();
            return tasks;
        }

        public async Task<IEnumerable<EmployeeTask>> GetByTaskState(TaskState taskState)
        {
            var filter = Builders<EmployeeTask>.Filter.Eq(x => x.TaskState, taskState);
            var tasks = await _employeeTasks.Find(filter).ToListAsync();
            return tasks;
        }

        public async Task<bool> Update(ObjectId objectId, EmployeeTask employeeTask)
        {
            var filter = Builders<EmployeeTask>.Filter.Eq(x => x.Id, objectId);
            var update = Builders<EmployeeTask>.Update
                .Set(x => x.IsDeleted, employeeTask.IsDeleted)
                .Set(x => x.Description, employeeTask.Description)
                .Set(x => x.Name, employeeTask.Name)
                .Set(x => x.TaskState, employeeTask.TaskState);
            var result = await _employeeTasks.UpdateOneAsync(filter, update);
            return result.ModifiedCount == 1;


        }
    }
}
