using Application.Interfaces;
using Domain.Entities;
using Domain.Entities.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedAt = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Event>? Events { get; set; }
        public DbSet<City>? Cities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            

            builder.Entity<Event>()
                .HasOne<Category>(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .HasOne<City>(e => e.City)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150);
            builder.Entity<Event>()
                .Property(e => e.CategoryId)
                .IsRequired();
            builder.Entity<Event>()
                .Property(e => e.CityId)
                .IsRequired();
            builder.Entity<Event>()
                .Property(e => e.Adress)
                .HasMaxLength(256);
            builder.Entity<Event>()
                .Property(e => e.AppUserId)
                .IsRequired();

            builder.Entity<AppUser>()
                .Property(a => a.Name)
                .HasMaxLength(100);
            builder.Entity<AppUser>()
                .Property(a => a.Surname)
                .HasMaxLength(100);

        }
    }
}
