using Pic.Shared.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pic.Shared.Interfaces
{
    public interface ICrudService<T> where T : DbEntity
    {
        void Add(T item);
        void Delete(Expression<Func<T, bool>> expression);
        IEnumerable<T>? Get();
        T? Get(Expression<Func<T, bool>> expression);
        void Update(T item);
        bool CheckIfExists(Expression<Func<T, bool>> expression);
    }
}