namespace Shop.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal  Price { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
