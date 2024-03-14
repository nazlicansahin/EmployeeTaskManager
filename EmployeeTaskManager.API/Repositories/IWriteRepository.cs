using System;
using EmployeeTaskManager.Domain.Common;

namespace EmployeeTaskManager.Application
{
    public interface IWriteRepository<T, TKey> where T : EntityBase<TKey>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(TKey id);
        Task SaveChangesAsync();
    }

}

