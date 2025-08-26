

namespace Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }       // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}

