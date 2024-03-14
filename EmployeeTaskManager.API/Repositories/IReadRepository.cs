﻿using System;
using EmployeeTaskManager.Domain.Common;
using System.Linq.Expressions;

namespace EmployeeTaskManager.Application
{
    public interface IReadRepository<T, TKey> where T : EntityBase<TKey>
    {
        IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> predicate, bool tracking = true);
        Task<T> GetById(TKey id, bool tracking = true);
    }

}

