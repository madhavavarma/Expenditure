﻿using Maddy.Apps.Expenditure.DataProvider.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maddy.Apps.Expenditure.Entities;

namespace Maddy.Apps.Expenditure.DataProvider.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IEntity
    {
        public ExpenditureContext expenditureContext;

        public GenericRepository(ExpenditureContext expenditureContext)
        {
            this.expenditureContext = expenditureContext;
        }

        public DbSet<TEntity> Query { get => this.expenditureContext.Set<TEntity>(); }

        public IQueryable<TEntity> GetAll()
        => this.Query.AsNoTracking();

        public async Task<TEntity> GetByIdAsync(int id)
        => await this.Query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);


        public async Task CreateAsync(TEntity entity)
        {
            await this.Query.AddAsync(entity);
            await expenditureContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, TEntity entity)
        {
            this.Query.Update(entity);
            await expenditureContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            this.Query.Remove(entity);
            await expenditureContext.SaveChangesAsync();
        }
    }
}