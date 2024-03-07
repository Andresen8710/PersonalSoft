using BrowserRentalCar.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrowserRentalCar.Infraestructure.Persistance
{
    public class BrowserRentalCarDBContext : DbContext
    {
        public BrowserRentalCarDBContext(DbContextOptions<BrowserRentalCarDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        //metodo para actualizar los campos de usuario y fecha antes de guardar la entidad
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = DateTime.Now;
                        entry.Entity.CreateBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Vehicle>? Vehicles { get; set; }

        public DbSet<Location>? Locations { get; set; }

        public DbSet<TravelHistory>? TravelHistories {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.TravelHistories)
                .WithOne(vh => vh.VehicleNavigation)
                .HasForeignKey(vh => vh.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Location>()
                .HasMany(vh => vh.OriginTravelHistories)
                .WithOne(v => v.OriginNavigation)
                .HasForeignKey(l => l.OriginId)
                .OnDelete(DeleteBehavior.NoAction); ;

            modelBuilder.Entity<Location>()
                .HasMany(vh => vh.DestinationTravelHistories)
                .WithOne(v => v.DestinationNavigation)
                .HasForeignKey(l => l.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.LocationNavigation)
                .WithMany()
                .HasForeignKey(v => v.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}