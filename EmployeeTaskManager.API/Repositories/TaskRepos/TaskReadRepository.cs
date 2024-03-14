using MongoDB.Driver;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace EmployeeTaskManager.Application.Repositories.Task
{
    public class TaskReadRepository : IReadRepository<Domain.Entities.Task, Guid>
    {
        private readonly IMongoCollection<TaskModel> _tasks;
        public TaskReadRepository(IMongoClient client) 
        {
            var database = client.GetDatabase("EmployeeTaskManagerDb");
            var collection = database.GetCollection<TaskModel>(nameof(Task));
            _tasks = collection;
        }

        public Task<IEnumerable<Domain.Entities.Task>> GetAll(Expression<Func<Domain.Entities.Task, bool>> predicate, bool tracking = true)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Entities.Task> GetById(ObjectId objectId, bool tracking = true)
        {
            var filter = Builders<TaskModel>.Filter.Eq(x => x.Id, objectId)
        }

        public IQueryable<Domain.Entities.Task> GetWhere(Expression<Func<Domain.Entities.Task, bool>> predicate, bool tracking = true)
        {
            throw new NotImplementedException();
        }

      //   Task<Domain.Entities.Task> GetByIdAsync(Guid id, bool tracking = true);

    }
}
