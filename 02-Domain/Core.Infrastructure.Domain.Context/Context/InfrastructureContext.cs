using Core.Infrastructure.Domain.Aggregate.RefTypeValue;
using Core.Infrastructure.Domain.Aggregate.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;

namespace Core.Infrastructure.Domain.Context.Context
{
    public class InfrastructureContext : IdentityDbContext<ApplicationUser>
    {
        //private readonly ILazyLoader lazyLoader;
        public InfrastructureContext()
        {
        }

        public InfrastructureContext(DbContextOptions<InfrastructureContext> options)
            : base(options)
        {
            //this.lazyLoader = lazyLoader;
            
        }

        public virtual DbSet<RefType> RefType { get; set; }
        public virtual DbSet<RefValue> RefValue { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(
                    "Data Source=TRISTICTL46W10;Initial Catalog=kemalakoglu; Persist Security Info=True;User ID=sa;Password=User123**;MultipleActiveResultSets=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<RefType>(entity => { modelBuilder.Entity<RefType>().OwnsOne(x => x.Parent); });
        }
    }
}