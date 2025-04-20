namespace NIFTWebApp.Modules.UserModule.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
    }


    public class CreateUserDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!; // assuming basic auth for now
    }


    public class UpdateUserDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
