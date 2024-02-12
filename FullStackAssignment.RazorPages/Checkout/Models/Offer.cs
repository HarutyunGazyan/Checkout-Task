namespace Checkout.Models
{
    public class Offer
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string? ExtraInfo { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
