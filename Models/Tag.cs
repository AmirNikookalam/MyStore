namespace Shop.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
