using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Pic.Shared.Repository
{
    public class LiteDbRepository<T> where T : DbEntity
    {
        private readonly string databaseUrl;
        public LiteDbRepository(string databaseUrl) => this.databaseUrl = databaseUrl;

        public IEnumerable<T>? Get()
        {
            using var db = new LiteDatabase(databaseUrl);
            return db.GetCollection<T>().Query().ToList();
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            using var db = new LiteDatabase(databaseUrl);
            return db.GetCollection<T>().Query().Where(expression).FirstOrDefault();
        }

        public bool CheckIfExists(Expression<Func<T, bool>> expression) => FirstOrDefault(expression) is object;

        public void Update(T item)
        {
            using var db = new LiteDatabase(databaseUrl);
            db.GetCollection<T>().Upsert(item);
        }

        public void Add(T item)
        {
            using var db = new LiteDatabase(databaseUrl);
            db.GetCollection<T>().Insert(item);
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            using var db = new LiteDatabase(databaseUrl);
            var entity = db.GetCollection<T>().Query().Where(expression).FirstOrDefault();
            if(entity is null)
            {
                throw new NullReferenceException("Item not found");
            }

            db.GetCollection<T>().Delete(entity.GetKey);
        }
    }
}