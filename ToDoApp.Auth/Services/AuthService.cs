using ToDoApp.Common.Exceptions;
using ToDoApp.Auth.Data.Abstract;
using ToDoApp.Auth.Services.Abstract;
using ToDoApp.Common.Models;

namespace ToDoApp.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;

        private const string UserNotFoundMessage = "There is no such a user!";
        private const string IncorrectPasswordMessage = "Incorrect password!";
        private const string UserAlreadyExistsMessage = "User with this username already exists!";

        public AuthService(IEmployeeRepository userRepository, ITokenService tokenService, IHashService hashService)
        {
            _employeeRepository = userRepository;
            _tokenService = tokenService;
            _hashService = hashService;
        }

        public async Task<AuthData> LoginAsync(LoginData loginData)
        {
            Employee? employeeFromDb = await _employeeRepository.GetByUsername(loginData.Username);

            if (employeeFromDb == null)
            {
                throw new NotFoundException(UserNotFoundMessage);
            }

            if (!_hashService.VerifyHash(loginData.Password, employeeFromDb.Password, employeeFromDb.Salt))
            {
                throw new BadRequestException(IncorrectPasswordMessage);
            }

            string token = _tokenService.GetToken(employeeFromDb);
            EmployeeUIData publicUser = new EmployeeUIData(employeeFromDb.Id, employeeFromDb.Username, employeeFromDb.Role, employeeFromDb.ImageName);

            return new AuthData(token, publicUser);
        }

        public async Task RegisterAsync(Employee employee)
        {
            Employee employeeFromDb = await _employeeRepository.GetByUsername(employee.Username);

            if (employeeFromDb != null)
            {
                throw new BadRequestException(UserAlreadyExistsMessage);
            }

            employee.Password = _hashService.GetHash(employee.Password, out byte[] salt);
            employee.Salt = salt;

            await _employeeRepository.CreateOneAsync(employee);
        }

        public async Task ChangePasswordAsync(ChangePasswordData changePasswordData)
        {
            Employee? employeeFromDb = await _employeeRepository.GetByUsername(changePasswordData.Username);

            if (employeeFromDb == null)
            {
                throw new NotFoundException(UserNotFoundMessage);
            }

            if (!_hashService.VerifyHash(changePasswordData.OldPassword, employeeFromDb.Password, employeeFromDb.Salt))
            {
                throw new BadRequestException(IncorrectPasswordMessage);
            }

            changePasswordData.Password = _hashService.GetHash(changePasswordData.Password, out byte[] salt);
            changePasswordData.Salt = salt;

            await _employeeRepository.ChangePasswordAsync(changePasswordData);
        }
    }
}
