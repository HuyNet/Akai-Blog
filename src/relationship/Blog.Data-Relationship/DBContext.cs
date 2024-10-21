using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Blog.Core_Relationship.Domain.Identity;
using Blog.Core_Relationship.Domain.Content;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

namespace Blog.Data_Relationship
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
        public DbSet<PostInTag> PostInTags { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new PostActivityLogConfiguration());
            builder.ApplyConfiguration(new PostCategoryConfiguration());
            builder.ApplyConfiguration(new PostInCategoryConfiguration());
            builder.ApplyConfiguration(new PostInSeriesConfiguration());
            builder.ApplyConfiguration(new PostInTagConfiguration());
            builder.ApplyConfiguration(new SeriesConfiguration());
            builder.ApplyConfiguration(new TagConfiguration());


            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);
            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRole").HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entityEntry in entities)
            {
                var dateCreatedProp = entityEntry.Entity.GetType().GetProperty("DateCreated");
                var dateModifiedProp = entityEntry.Entity.GetType().GetProperty("DateModified");
                if (entityEntry.State == EntityState.Added && dateCreatedProp != null)
                {
                    dateCreatedProp.SetValue(entityEntry.Entity, DateTime.Now);
                }
                if (entityEntry.State == EntityState.Modified && dateCreatedProp != null)
                {
                    dateModifiedProp.SetValue(entityEntry.Entity, DateTime.Now);
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
