using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pic.Database.Data.Entities;
using Pic.Database.Interfaces;

namespace Pic.Database.Abstraction
{
    public class GenericService<T> where T: BaseEntity
    {
        protected readonly IContext context;

        public GenericService(IContext context) => this.context = context;

        public async Task<T> Get(Expression<Func<T, bool>> expression) => await context.GetDbSet<T>().FirstOrDefaultAsync(expression);

        public async Task<IEnumerable<T>> GetAll() => await context.GetDbSet<T>().ToListAsync();

        public async Task Delete(params T[] entities)
        {
            context.GetDbSet<T>().RemoveRange(entities);

            await context.SaveChangesAsync();
        }

        public async Task<int[]> Add(params T[] entities)
        {
            context.GetDbSet<T>()
                .AddRange(entities);

            await context.SaveChangesAsync();

            return entities.Select(x => x.Id)
                .ToArray();
        }

        public async Task MarkAsDeleted(Expression<Func<T, bool>> expression) => await MarkAs(expression, true);

        public async Task MarkAsNotDeleted(Expression<Func<T, bool>> expression) => await MarkAs(expression, false);

        private async Task MarkAs(Expression<Func<T, bool>> expression, bool deleted)
        {
            var entity = await Get(expression);
            if(entity is null)
            {
                throw new NullReferenceException($"{typeof(T).Name} does not exists!");
            }

            entity.Deleted = deleted;

            await context.SaveChangesAsync();
        }
    }
}