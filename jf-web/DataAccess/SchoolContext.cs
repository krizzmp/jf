using jf_web.Domain;
using Microsoft.EntityFrameworkCore;

namespace jf_web.DataAccess {
    public class SchoolContext : DbContext {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}