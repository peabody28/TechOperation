using core;
using entities;
using entities.Interfaces;
using FluentValidation.AspNetCore;
using operations.Interfaces;
using operations.Operations;
using repositories;
using repositories.DtoBuilders;
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
        builder.Services.AddScoped<PostgresBank, PostgresBank>();

        builder.Services.AddScoped<EventDtoBuilder, EventDtoBuilder>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IEventRepository, EventRepository>();

        builder.Services.AddScoped<IEventOperation, EventOperation>();

        builder.Services.AddScoped<IUser, UserEntity>();
        builder.Services.AddScoped<IRole, RoleEntity>();
        builder.Services.AddScoped<IEvent, EventEntity>();

        builder.Services.AddMvc(opt =>
        {
            opt.Filters.Add(typeof(ValidatorActionFilter));
            opt.EnableEndpointRouting = false;
        });
        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddFluentValidation(s =>
        {
            s.RegisterValidatorsFromAssemblyContaining<Program>();
        });

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