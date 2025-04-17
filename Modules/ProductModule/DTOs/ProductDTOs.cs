namespace NIFTWebApp.Modules.ProductModule.DTOs
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public int VendorId { get; set; }
        public int CategoryId { get; set; }
    }

    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public string ImageUrl { get; set; }
        public string VendorName { get; set; }
        public string CategoryName { get; set; }
    }

    public class UpdateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal StartingPrice { get; set; }
        public string ImageUrl { get; set; } // Optional: if you allow image changes on update
        public int CategoryId { get; set; }
    }

}
