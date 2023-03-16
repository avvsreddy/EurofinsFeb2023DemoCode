namespace CrezyProductsCatalogService.Models.DomainModels
{
    public class CrezyProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Catagory { get; set; }
        public string Country { get; set; }
    }
}