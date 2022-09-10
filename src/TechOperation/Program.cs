using entities;
using entities.Interfaces;
using repositories;
using repositories.Interfaces;
using repositories.Repositories;

public class Program
{
    public static void Main(string[] args)
    {
        //Add services to the container.

        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        builder.Services.AddScoped<Bank, Bank>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();

        builder.Services.AddScoped<IUser, UserEntity>();
        builder.Services.AddScoped<IRole, RoleEntity>();

        builder.Services.AddMvc(opt =>
        {
            //opt.Filters.Add(typeof(ValidatorActionFilter));
            opt.EnableEndpointRouting = false;
        });
        // Add services to the container.

        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}