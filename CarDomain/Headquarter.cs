namespace CarDomain
{
    public class Headquarter
    {
        public int HeadquarterId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
