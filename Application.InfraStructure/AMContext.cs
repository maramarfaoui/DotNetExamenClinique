using Application.InfraStructure.Configuration;
using Microsoft.EntityFrameworkCore;


namespace AM.Infrastructure
{
    public class AMContext: DbContext
    {

       /* public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
              Initial Catalog=CliniqueDB;MultipleActiveResultSets=true;Integrated Security=true") ;
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.ApplyConfiguration(new PlaneConfiguration());
             modelBuilder.ApplyConfiguration(new FlightConfiguration());
             modelBuilder.ApplyConfiguration(new PassengerConfiguration());
             modelBuilder.ApplyConfiguration(new TicketConfiguration());

             modelBuilder.Entity<Staff>().ToTable("Staff");
             modelBuilder.Entity<Traveller>().ToTable("Travellers");*/
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                 .SelectMany(t => t.GetProperties())
                 .Where(p => p.ClrType == typeof(string)))
            {
                property.IsNullable = false;
            }
            modelBuilder.ApplyConfiguration(new ChambreConfiguration());
            modelBuilder.ApplyConfiguration(new AdmissionConfiguration());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
        //    // Pre-convention model configuration goes here
        //    configurationBuilder
        //        .Properties<string>()
        //        .HaveMaxLength(50);
        //configurationBuilder
        //    .Properties<decimal>()
        //        .HavePrecision(8,3);
            /*configurationBuilder
              .Properties<DateTime>()
                  .HaveColumnType("date");*/
        }



    }
}
