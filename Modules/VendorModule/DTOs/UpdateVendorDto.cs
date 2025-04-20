namespace NIFTWebApp.Modules.VendorModule.DTOs
{
    public class UpdateVendorDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string? PhoneNumber { get; set; }
    }


}
