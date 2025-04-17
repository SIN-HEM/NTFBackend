using NIFTWebApp.Modules.UserModule.Entities;
using NIFTWebApp.Modules.UserModule.Interfaces;

namespace NIFTWebApp.Modules.UserModule.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto?> GetByIdAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            return _mapper.Map<UserDto?>(user);
        }

        public async Task<UserDto> CreateAsync(CreateUserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            await _repo.AddAsync(user);
            return _mapper.Map<UserDto>(user);
        }
    }
}
