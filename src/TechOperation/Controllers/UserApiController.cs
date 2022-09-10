using core;
using Microsoft.AspNetCore.Mvc;
using repositories.Interfaces;
using TechOperations.ModelBuilder;
using TechOperations.Models.User;

namespace TechOperations.Controllers
{
    public class UserApiController : BaseApiController
    {
        private IUserRepository UserRepository { get; set; }

        public UserApiController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        [HttpGet]
        public List<UserModel> Users()
        {
            var users = UserRepository.Collection();
            return users.Select(user => UserModelBuilder.Build(user)).ToList();
        }

        [HttpPost]
        public UserModel Login(LoginModel model)
        {
            var user = UserRepository.ObjectByPhone(model.PhoneNumber);
            return UserModelBuilder.Build(user);
        }
    }
}
