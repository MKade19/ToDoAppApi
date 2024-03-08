using ToDoApp.Exceptions;
using ToDoApp.Models;
using ToDoApp.Repositories.Abstract;
using ToDoApp.Services.Abstract;

namespace ToDoApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;

        private const string UserNotFoundMessage = "There is no such a user!";
        private const string IncorrectPasswordMessage = "Incorrect password!";
        private const string UserAlreadyExistsMessage = "User with this username already exists!";

        public AuthService(IUserRepository userRepository, ITokenService tokenService, IHashService hashService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _hashService = hashService;
        }

        public async Task<AuthData> LoginAsync(User user)
        {
            User? userFromDb = await _userRepository.GetByUsername(user.Username);

            if (userFromDb == null)
            {
                throw new NotFoundException(UserNotFoundMessage);
            }

            if (!_hashService.VerifyHash(user.Password, userFromDb.Password, userFromDb.Salt))
            {
                throw new BadRequestException(IncorrectPasswordMessage);
            }

            string token = _tokenService.GetToken(userFromDb);

            return new AuthData(token);
        }

        public async Task RegisterAsync(User user)
        {
            User? userFromDb = await _userRepository.GetByUsername(user.Username);

            if (userFromDb != null)
            {
                throw new BadRequestException(UserAlreadyExistsMessage);
            }

            user.Password = _hashService.GetHash(user.Password, out byte[] salt);
            user.Salt = salt;

            await _userRepository.CreateOneAsync(user);
        }
    }
}
