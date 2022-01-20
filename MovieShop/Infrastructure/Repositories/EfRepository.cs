using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;
        public EfRepository(MovieShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual Task Delete(int id)
        {
            /*            _dbContext.Set<T>().Remove
                        await _dbContext.SaveChangesAsync();
                        *//*            _dbContext.Set<T>().Remove(_dbContext.Set<T>().Where(x => x == id));
                                    _dbContext.SaveChangesAsync();*//*
                        return entity;
            */
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var data = await _dbContext.Set<T>().ToListAsync();
            return data;
        }

        public virtual async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> filter)
        {
            var data = await _dbContext.Set<T>().Where(filter).ToListAsync();
            return data;
        }

        public virtual async Task<T> GetById(int id)
        {
            var entity = await _dbContext.Set<T>().FindAsync();
            return entity;
        }

        public virtual Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
