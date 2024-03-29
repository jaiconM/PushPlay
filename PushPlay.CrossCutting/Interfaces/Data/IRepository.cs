﻿using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace PushPlay.CrossCutting.Interfaces.Data
{
    public interface IRepository<T> where T : class
    {
        Task Save(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T?> Get(object id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T?>> FindAllByCriteria(Expression<Func<T, bool>> expression);
        Task<T?> FindOneByCriteria(Expression<Func<T, bool>> expression);

        Task<IDbContextTransaction> CreatTransaction();
        Task<IDbContextTransaction> CreatTransaction(IsolationLevel isolation);
    }
}
