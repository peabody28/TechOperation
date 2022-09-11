﻿using core;
using repositories.Interfaces;
using TechOperation.Models.User;
using TechOperation.ModelBuilder;
using Microsoft.AspNetCore.Mvc;

namespace TechOperation.Controllers
{
    public class UserApiController : BaseApiController
    {
        #region [ Dependency -> Repositories ]

        private IUserRepository UserRepository { get; set; }

        private IRoleRepository RoleRepository { get; set; }

        #endregion

        public UserApiController(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            UserRepository = userRepository;
            RoleRepository = roleRepository;
        }

        [HttpGet]
        public List<UserModel> Users()
        {
            var users = UserRepository.Collection();
            return users.Select(user => UserModelBuilder.Build(user)).ToList();
        }

        [HttpGet]
        public UserModel User(string name)
        {
            var user = UserRepository.Object(name);
            return UserModelBuilder.Build(user);
        }

        [HttpPost]
        public UserModel Login(LoginModel model)
        {
            var user = UserRepository.ObjectByPhone(model.PhoneNumber);
            return UserModelBuilder.Build(user);
        }

        [HttpPost]
        public UserModel Create(CreateUserModel model)
        {
            var role = RoleRepository.Object(model.RoleCode);

            var user = UserRepository.Create(role, model.TelegramId, model.Name, model.PhoneNumber);
            return UserModelBuilder.Build(user);
        }
    }
}
