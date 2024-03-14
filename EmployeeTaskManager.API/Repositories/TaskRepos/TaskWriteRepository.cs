using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTaskManager.Application.Repositories.Task
{
    public class TaskWriteRepository: IWriteRepository<Domain.Entities.Task, Guid>
    {

        private readonly IMongoCollection<TaskModel> _tasks;
        public TaskWriteRepository(IMongoClient client)
        {
            var database = client.GetDatabase("EmployeeTaskManagerDb");
            var collection = database.GetCollection<TaskModel>(nameof(Task));
            _tasks = collection;
        }
        public async Task<ObjectId>  AddAsync(TaskModel task)
        {
            await _tasks.InsertOneAsync(task);
            return task.Id; //burada Id tipi objectId ilerde Guidden kaynakli problem cikabilir
        }

        public System.Threading.Tasks.Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task UpdateAsync(Domain.Entities.Task entity)
        {
            throw new NotImplementedException();
        }

  
    
    }
}
