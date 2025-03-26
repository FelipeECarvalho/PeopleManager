using Microsoft.EntityFrameworkCore;
using PeopleManager.Domain.Entities;

namespace PeopleManager.Persistence
{
    public class PeopleManagerContext : DbContext
    {
        public PeopleManagerContext(DbContextOptions<PeopleManagerContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; } = default!;
    }
}
