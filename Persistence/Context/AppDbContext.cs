using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Event>? Events { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
           
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
                .Property(e => e.UserId)
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
