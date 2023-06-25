using Data.Repository.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly OnlineShoppingContext context;
        private DbSet<T> Table => context.Set<T>();
        public GenericRepository(OnlineShoppingContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            await Table.AddAsync(entity);
        }

        public void Delete(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Table.ToListAsync();
        }

        public T GetById(int id)
        {
            return Table.Find(id);
        }

        public IEnumerable<T> GetValuesByExpression(Expression<Func<T, bool>> expression)
        {
            return Table.Where(expression);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task AddAndCommit(T entity)
        {
            await Add(entity);
            await Commit();
        }


        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }

        public IQueryable<T> GetAllTable()
        {
            IQueryable<T> table = Table;
            var a = table.Where(m => m.ToString() == "sa");
            return table;
        }
    }
}
