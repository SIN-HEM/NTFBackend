using AutoMapper;
using NIFTWebApp.Modules.UserModule.DTOs;
using NIFTWebApp.Modules.UserModule.Entities;
using NIFTWebApp.Modules.UserModule.Interfaces;

namespace NIFTWebApp.Modules.UserModule.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var u = new User
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password), // Hash the password
                Role = "User"
            };
            var user = _mapper.Map<User>(u);
            await _repository.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task UpdateAsync(int id, UpdateUserDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("User not found");

            _mapper.Map(dto, existing);
            await _repository.UpdateAsync(existing);
        }

        public async Task DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) throw new Exception("User not found");

            await _repository.DeleteAsync(id);
        }
    }

}
