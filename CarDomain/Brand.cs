namespace CarDomain
{
    public class Brand
    {
        public Brand()
        {
            Models = new List<Model>();
        }
        public int BrandId { get; set; }
        public string Name { get; set; }
      
        public List<Model> Models { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public Headquarter Headquarter { get; set; }
    }
}
