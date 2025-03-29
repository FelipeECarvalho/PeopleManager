using Microsoft.EntityFrameworkCore;
using PeopleManager.Core.Entities;

namespace PeopleManager.Infrastructure.Persistence
{
    public class PeopleManagerContext(DbContextOptions<PeopleManagerContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<Person> Person { get; set; } = default!;
    }
}