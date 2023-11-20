namespace CarDomain
{
    public class ProductionCountry
    {
        public int ProductionCountryId { get; set; }
        public string Name { get; set; }
        public string ISO3166Code { get; set; }
        public List<Brand> Brands { get; set; } = new List<Brand>();
    }
}
