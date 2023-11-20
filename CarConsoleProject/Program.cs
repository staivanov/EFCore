using CarData;
using CarDomain;
using Microsoft.EntityFrameworkCore;

namespace CarConsoleProject
{
    internal class Program
    {
        private static readonly CarContext _context = new();

        static void Main()
        {
            string carBrand = "Porsche";
            QueryProjectionBrandWithModelNameAndYear(carBrand);

        }

        private static void EagerLoadBrandWithModels(string brandName)
        {
            Brand? brandWithModels = _context.Brands
                 .Where(b => b.Name == brandName)
                 .Include(m => m.Models)
                 .FirstOrDefault();

            Console.WriteLine($"{brandName} models are: ");

            foreach (var model in brandWithModels.Models)
            {
                Console.WriteLine(model.Name);
            }
        }


        private static void QueryProjectionBrandWithModelNameAndYear(string brandName)
        {
            var unknowTypes = _context.Brands.Where(b => b.Name == brandName)
                .Select(t => new
                {
                    BrandName = t.Name,
                    ModelName = t.Models
                }).ToList();

            Console.WriteLine($"Brand: {brandName}");
            Console.WriteLine("Name of model and release date: ");

            foreach (var unknowType in unknowTypes)
            {
                foreach (var carModel in unknowType.ModelName)
                {
                    Console.WriteLine($"{carModel.Name} ---- {carModel.ReleaseDate.Year}");
                }
            }
        }


        private static void ExplicitLoadBrandCollection(string brandName)
        {
            Brand? currentBrand = _context.Brands
                .FirstOrDefault(b => b.Name == brandName);
            //Load entities already memory.
            _context.Entry(currentBrand).Collection(m => m.Models).Load();
        }


        private static void FilterBrandsByModelsAboveSomeReleaseDate(int releaseDateYear)
        {
            List<Brand> brands = _context.Brands
                .Where(b => b.Models.Any(r => r.ReleaseDate.Year > releaseDateYear))
                .ToList();

            Console.WriteLine($"Brands with models above {releaseDateYear} year.");

            foreach (var brand in brands)
            {
                Console.WriteLine(brand.Name);
            }
        }


        private static void CreateNewProductionCountryForBrand(ProductionCountry productionCountry, string brandName)
        {
            //Many to many relationship
            Brand? brand = _context.Brands.FirstOrDefault(b => b.Name == brandName);
            ProductionCountry country = new()
            {
                Name = productionCountry.Name,
                ISO3166Code = productionCountry.ISO3166Code
            };

            country.Brands.Add(brand);
            _context.ProductionCountries.Add(country);
            _context.SaveChanges();
        }


        private static void CreateNewBrandWithNewCountryProduction(Brand newBrand, ProductionCountry productionCountry)
        {
            _context.Brands.Add(newBrand);
            productionCountry.Brands.Add(newBrand);
            _context.ProductionCountries.Add(productionCountry);
            _context.SaveChanges();
        }


        private static Brand GetBrandWithProductinCountries(string brandName)
        {
            Brand? brandWithProductCountries = _context.Brands
                .Include(p => p.ProductionCountries)
                .Where(b => b.Name == brandName).FirstOrDefault();

            return brandWithProductCountries;
        }


        private static void ReassignCountryProduction(string brandName, string countryFrom, string countryTo)
        {
            //Many to many relationships. Reassining one country production to other.
            Brand? carWithCountries = _context.Brands
                .Where(b => b.Name == brandName)
                .Include(c => c.ProductionCountries.Where(n => n.Name == countryFrom))
                .FirstOrDefault();

            carWithCountries.ProductionCountries.RemoveAt(0);

            ProductionCountry? productionCountry = _context.ProductionCountries
                .Where(c => c.Name == countryTo)
                .FirstOrDefault();

            carWithCountries.ProductionCountries.Add(productionCountry);
            _context.Brands.Update(carWithCountries);
            _context.SaveChanges();
        }


        private static Brand GetBrandWithHeadquarter(string brandName)
        {
            //One to one relationship.
            Brand? brandWithHeadquarter = _context.Brands.Where(n => n.Name == brandName)
                .Include(h => h.Headquarter)
                .FirstOrDefault();

            return brandWithHeadquarter;
        }


        private static void AddNewBrandWithHeadquarter(Brand newBrand, Headquarter headquarter)
        {
            //Add new entities in one to one relationship.
            newBrand.Headquarter = headquarter;
            _context.Brands.Add(newBrand);
            _context.SaveChanges();
        }
    }
}
