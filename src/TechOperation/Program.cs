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
        builder.Services.AddScoped<IEventRepository, EventRepository>();

        builder.Services.AddScoped<IUser, UserEntity>();
        builder.Services.AddScoped<IRole, RoleEntity>();
        builder.Services.AddScoped<IEvent, EventEntity>();

        builder.Services.AddMvc(opt =>
        {
            //opt.Filters.Add(typeof(ValidatorActionFilter));
            opt.EnableEndpointRouting = false;
        });
        // Add services to the container.

        builder.Services.AddControllers();

        var app = builder.Build();

        app.UseDeveloperExceptionPage();
        // Configure the HTTP request pipeline.
        app.UseRouting();

        app.UseAuthorization();

        app.UseCors(builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.Run();
    }
}