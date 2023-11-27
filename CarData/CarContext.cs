using CarDomain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarData
{
    public class CarContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ProductionCountry> ProductionCountries { get; set; }
        public DbSet<BrandNameWithHeadquarterName> BrandsNamesWithHeadquarters { get; set; }

        public CarContext()
        {
        }


        public CarContext(DbContextOptions<CarContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   //Connection string is here only for a demo purpose. 
                string connectionString = $"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CarDatabase";
                optionsBuilder.UseSqlServer(connectionString).LogTo(Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information);
            }
        }


        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    //Bulk configuration
        //    configurationBuilder.Properties<Brand>().HaveColumnType("varchar(100)");

        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, Name = "Porsche" });

            var brandsList = new Brand[]{
                new() {BrandId = 2, Name = "BMW" },
                new() {BrandId = 3, Name = "Mercedes"},
                new() {BrandId = 4, Name = "VW" },
                new() {BrandId = 5, Name = "Toyota"},
                new() {BrandId = 6, Name = "Lexus"}
            };
            modelBuilder.Entity<Brand>().HasData(brandsList);

            //Prevent creating table with entities
            modelBuilder.Entity<BrandNameWithHeadquarterName>().HasNoKey()
                .ToView("BrandsNamesWithHeadquarterName");

            //modelBuilder.Entity<Brand>()
            //    .HasMany<Model>()
            //    .WithOne();
        }
    }
}
