using Microsoft.EntityFrameworkCore;

namespace MVC.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<MVC.Models.Bird> Birds { get; set; }
    }
}
