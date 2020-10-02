using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Pic.Migrations
{
    public class PicDbContext : IdentityDbContext
    {
        public PicDbContext(DbContextOptions<PicDbContext> options) : base(options)
        {
        }
    }
}