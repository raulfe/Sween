using Microsoft.EntityFrameworkCore;
using Sween.Core.Entities;
using System.Reflection;

namespace Sween.Infrastructure.Data
{
    public partial class SweenContext : DbContext
    {
        public SweenContext()
        {
        }

        public SweenContext(DbContextOptions<SweenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Groups> Groups { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UsersGroup> UsersGroup { get; set; }
        public virtual DbSet<Security> Securities { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
