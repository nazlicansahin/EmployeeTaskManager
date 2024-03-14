using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EmployeeTaskManager.Domain.Common;

namespace EmployeeTaskManager.Application
{
    public interface IRepository<T, TKey> where T : EntityBase<TKey>
    {
        DbSet<T> Table { get; }
    }
}

