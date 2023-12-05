using Microsoft.EntityFrameworkCore;
using OrdersWeb.DAL.Data;
using OrdersWeb.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrdersWeb.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext context;

        public Repository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? context.Set<T>() : context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? context.Set<T>().Where(expression) : context.Set<T>().Where(expression).AsNoTracking();
        }
        public async Task CreateAsync(T entity)
        {
            context.Set<T>().Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }
           
        public async Task UpdateAsync(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
