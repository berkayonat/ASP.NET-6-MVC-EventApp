using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Context
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Event>? Events { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            

            builder.Entity<Event>()
                .HasOne<Category>(e => e.Category)
                .WithMany(c => c.Events)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Entity<Event>()
                .Property(e => e.CategoryId)
                .IsRequired();
            
            builder.Entity<Event>()
                .Property(e => e.CityId)
                .IsRequired();
            builder.Entity<Event>()
                .Property(e => e.Adress)
                .HasMaxLength(150);
            builder.Entity<Event>()
                .Property(e => e.UserId)
                .IsRequired();

        }
    }
}
