namespace CarDomain
{
    public class Model
    {
        public int ModelId { get; set; }
        public string Name { get; set; }
        public int BuildedNumber { get; set; }
        public DateTime ReleaseDate { get; set; }

        //FK property
        public int BrandId { get; set; }
        //Navigation property
        public Brand Brand { get; set; }
    }
}
