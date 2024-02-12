namespace Checkout.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Country Country { get; set; }
        public virtual IEnumerable<Offer> Offers { get; set; }
    }
}
