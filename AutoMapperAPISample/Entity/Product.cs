namespace AutoMapperAPISample.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool IsArchived { get; set; }
        public long TimeStamp { get; set; }
    }
}
