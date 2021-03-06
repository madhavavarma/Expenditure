﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Maddy.Apps.Expenditure.DataProvider.Repositories
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        DbContext Context { get; }

        DbSet<TEntity> Query { get; }

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, object>> include);

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> GetByIdAsync(int id, Expression<Func<TEntity, object>> include);

        Task<TEntity> CreateAsync(TEntity entity);

        Task UpdateAsync(int id, TEntity entity);

        Task DeleteAsync(int id);
    }
}
