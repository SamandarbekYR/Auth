using Auth.DataAccess.Repository.Users;
using Auth.DTOs.UserDto;
using Auth.Entity.Users;
using Auth.Services.TokenService;

namespace Auth.Services.Users
{
    public class UserService
    {
        private UsersRepository _repos;
        private Token _token;

        public UserService(UsersRepository repo, Token tokenService)
        {
            _repos = repo;
            _token = tokenService;
        }
        public string Add(UserCreateDto dto)
        {
            User user = new User();
            user.Name = dto.Name;
           
            _repos.Add(user);
            var str = _token.GetToken(user);

            return str;
        }
    }
}
