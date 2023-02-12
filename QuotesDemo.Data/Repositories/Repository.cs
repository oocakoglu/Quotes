using Microsoft.EntityFrameworkCore;
using QuotesDemo.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuotesDemo.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAllQuery()
        {
            return Context.Set<TEntity>().AsQueryable();
        }

        public ValueTask<TEntity?> GetByIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }


        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        //public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        //}

        //public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return Context.Set<TEntity?>().FirstOrDefaultAsync(predicate);
        //}

        public async Task<int> GetCountAll()
        {
            return await Context.Set<TEntity>().CountAsync();
        }

        public Task<int> GetCountSome(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }


    }
}
