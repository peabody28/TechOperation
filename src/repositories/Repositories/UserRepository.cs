﻿using entities;
using entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using repositories.Interfaces;

namespace repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private Bank Bank { get; set; }

        private IServiceProvider Container { get; set; }

        public UserRepository(Bank database, IServiceProvider serviceProvider)
        {
            Bank = database;
            Container = serviceProvider;
        }

        public IUser Create(IRole role, int telegramId, string name, string phoneNumber)
        {
            var entity = Container.GetRequiredService<IUser>();
            entity.Id = Guid.NewGuid();
            entity.RoleId = role.Id;
            entity.TelegramId = telegramId;
            entity.Name = name;
            entity.PhoneNumber = phoneNumber.Replace("+", string.Empty);

            var user = Bank.User.Add(entity as UserEntity);
            Bank.SaveChanges();
            user.Entity.Role = role;
            return user.Entity;
        }

        public IUser Object(string name)
        {
            var user = Bank.User.Include(c => c.Role).FirstOrDefault(user => user.Name.Equals(name));
            return user;
        }

        public IUser Object(int telegramId)
        {
            var user = Bank.User.Include(c => c.Role).FirstOrDefault(user => user.TelegramId.Equals(telegramId));
            return user;
        }

        public IUser ObjectByPhone(string phoneNumber)
        {
            var user = Bank.User.Include(c => c.Role).FirstOrDefault(user => user.PhoneNumber.Equals(phoneNumber));
            return user;
        }

        public IEnumerable<IUser> Collection(string roleCode = null)
        {
            return Bank.User.Include(c => c.Role).Where(user => roleCode != null ? user.Role.Code.Equals(roleCode) : true).Cast<IUser>();
        }
    }
}
