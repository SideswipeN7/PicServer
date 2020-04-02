using System;
using System.Collections.Generic;
using Pic.Shared.Interfaces;
using Microsoft.Extensions.Logging;
using Pic.Shared.Abstraction;
using System.Linq.Expressions;

namespace Pic.Server.Services
{
    public class CrudService<T> : ICrudService<T> where T : DbEntity
    {
        private readonly ILogger<T> logger;
        private readonly IRepository<T> repository;

        public CrudService(ILogger<T> logger, IRepository<T> repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        public void Add(T item)
        {
            try
            {
                repository.Add(item);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to {nameof(Add)} in {nameof(CrudService<T>)}");

                throw;
            }
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            try
            {
                repository.Delete(expression);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to {nameof(Delete)} in {nameof(CrudService<T>)}");

                throw;
            }
        }

        public IEnumerable<T>? Get()
        {
            try
            {
                return repository.Get();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to {nameof(Get)} in {nameof(CrudService<T>)}");

                throw;
            }
        }

        public T? Get(Expression<Func<T, bool>> expression)
        {
            try
            {
                return repository.FirstOrDefault(expression);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to {nameof(Get)} in {nameof(CrudService<T>)}");

                throw;
            }
        }

        public void Update(T item)
        {
            try
            {
                repository.Update(item);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to {nameof(Update)} in {nameof(CrudService<T>)}");

                throw;
            }
        }

        public bool CheckIfExists(Expression<Func<T, bool>> expression)
        {
            try
            {
                return repository.CheckIfExists(expression);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Failed to {nameof(CheckIfExists)} in {nameof(CrudService<T>)}");

                throw;
            }
        }
    }
}