using CarData;
using CarDomain;
using Microsoft.EntityFrameworkCore;

namespace CarAppTest
{
    [TestClass]
    public class DatabaseTests
    {
        private const string connectionString = $"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = CarTestDatabase";
        private DbContextOptionsBuilder<CarContext> _builder = new();

        [TestMethod]
        public void CanInserBrandIntoDatabase()
        {
            _builder.UseSqlServer(connectionString);

            using var context = new CarContext(_builder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Brand testBrand = new()
            {
                Name = "Test",
                Models = new List<Model>()
                {
                    new() {Name = "Model1", BuildedNumber = 5555, ReleaseDate = DateTime.Now},
                    new() {Name = "Model2", BuildedNumber = 6666, ReleaseDate = DateTime.Now},
                    new() {Name = "Model3", BuildedNumber = 7777, ReleaseDate = DateTime.Now}
                },
                Headquarter = new()
                {
                    Name = "Test Headquarter",
                    Address = "Exotic place on test database",
                }
            };

            context.Brands.Add(testBrand);
            context.SaveChanges();

            Assert.AreNotEqual(0, testBrand.BrandId);
        }


        [TestMethod]
        public void CanInsertNewProductionCountry()
        {
            _builder.UseSqlServer(connectionString);
            using var context = new CarContext(_builder.Options);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            ProductionCountry newTestProductionCountry = new()
            {
                Name = "TestCountry",
                ISO3166Code = "TS",
            };

            context.ProductionCountries.AddAsync(newTestProductionCountry);
            context.SaveChanges();

            Assert.AreNotEqual(0, newTestProductionCountry.ProductionCountryId);
        }
    }
}