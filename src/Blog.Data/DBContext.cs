using Blog.Core.Domian.Content;
using Blog.Core.Domian.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Blog.Data
{
    public class DBContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<PostActivityLog> PostActivityLogs { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
        public DbSet<PostInSeries> PostInSeries { get; set; }
        public DbSet<PostTag> PostTags  { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x=>x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x=> x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x=>x.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRole").HasKey(x=> new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entites = ChangeTracker
                .Entries()
                .Where(e=> e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entites) 
            {
                var dateCreatedProp = entityEntry.Entity.GetType().GetProperty("DateCreated");
                var dateModifeidProp = entityEntry.Entity.GetType().GetProperty("DateModifeid");
                if (entityEntry.State == EntityState.Added && dateCreatedProp != null)
                {
                    dateCreatedProp.SetValue(entityEntry.Entity,DateTime.Now);
                }
                if (entityEntry.State == EntityState.Modified && dateCreatedProp != null)
                {
                    dateModifeidProp.SetValue(entityEntry.Entity, DateTime.Now);
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
