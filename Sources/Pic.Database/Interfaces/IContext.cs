using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pic.Database.Data.Entities;

namespace Pic.Database.Interfaces
{
    public interface IContext
    {
        DbSet<T> GetDbSet<T>() where T : BaseEntity;

        Task<int> SaveChangesAsync();
    }
}