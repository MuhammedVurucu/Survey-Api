﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Survey.Application.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);

        Task<int> CountAsync();  // <-- Toplam veri sayısı

        Task<IEnumerable<T>> GetPagedAsync(int pageNumber, int pageSize);
        Task<IEnumerable<T>> GetPagedOrderedAsync<TKey>(int pageNumber, int pageSize, Expression<Func<T, TKey>> orderBy, bool descending = false);


        Task<bool> SaveChangesAsync();

 
    }
}
