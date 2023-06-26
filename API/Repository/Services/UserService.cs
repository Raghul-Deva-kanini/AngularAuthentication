using JWTAuthenticationApp.Interfaces;
using JWTAuthenticationApp.Models.DTO;
using JWTAuthenticationApp.Models;
using System.Security.Cryptography;
using System.Text;
using RoleBasedAuthorization.Models;

namespace JWTAuthenticationApp.Services
{
    public class UserService
    {
        private IBaseRepo<string, User> _repo;
        private ITokenGenerate _tokenService;

        public UserService(IBaseRepo<string, User> repo, ITokenGenerate tokenGenerate)
        {
            _repo = repo;
            _tokenService = tokenGenerate;
        }
        public UserDTO Login(UserDTO userDTO)
        {
            UserDTO user = null;
            var userData = _repo.Get(userDTO.Id);
            if (userData != null)
            {
                var hmac = new HMACSHA512(userData.HashKey);
                var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                for (int i = 0; i < userPass.Length; i++)
                {
                    if (userPass[i] != userData.Password[i])
                        return null;
                }
                user = new UserDTO();
                user.Id = userData.Id;
                user.Role = userData.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
        public UserDTO Register(UserRegisterDTO userDTO)
        {
            UserDTO user = null;
            var hmac = new HMACSHA512();
            userDTO.Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.PasswordClear));
            userDTO.HashKey = hmac.Key;
            var resultUser = _repo.Add(userDTO);
            if (resultUser != null)
            {
                user = new UserDTO();
                user.Id = resultUser.Id;
                user.Email=resultUser.Email;
                user.Role = resultUser.Role;
                user.Token = _tokenService.GenerateToken(user);
            }
            return user;
        }
    }
}
