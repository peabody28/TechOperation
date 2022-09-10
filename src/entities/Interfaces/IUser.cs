using System;

namespace entities.Interfaces
{
    public interface IUser
    {
        Guid Id { get; set; }

        int TelegramId { get; set; }

        string Name { get; set; }

        Guid RoleFk { get; set; }
        IRole Role { get; set; }

        string PhoneNumber { get; set; }
    }
}
