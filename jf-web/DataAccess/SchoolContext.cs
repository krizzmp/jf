using jf_web.Domain;
using Microsoft.EntityFrameworkCore;

namespace jf_web.DataAccess {
    public class ApplicationContext : DbContext {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        }

        public DbSet<Member> Members { get; set; }
        // ReSharper disable once UnusedMember.Global
        public DbSet<Employee> Employees { get; set; }
    }
}