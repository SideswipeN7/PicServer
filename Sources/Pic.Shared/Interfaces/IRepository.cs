using Pic.Shared.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pic.Shared.Interfaces
{
    public interface IRepository<T> where T : DbEntity
    {
        IEnumerable<T>? Get();
        T? FirstOrDefault(Expression<Func<T, bool>> expression);
        bool CheckIfExists(Expression<Func<T, bool>> expression);
        void Update(T item);
        void Add(T item);
        void Delete(Expression<Func<T, bool>> expression);
    }
}