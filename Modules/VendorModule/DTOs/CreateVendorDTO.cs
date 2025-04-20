namespace NIFTWebApp.Modules.VendorModule.DTOs
{
    public class CreateVendorDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public string Email { get; set; } = default!;
        public string? PhoneNumber { get; set; }
    }


}
