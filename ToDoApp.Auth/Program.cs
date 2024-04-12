using Microsoft.EntityFrameworkCore;
using ToDoApp.Auth.Data;
using ToDoApp.Auth.Data.Abstract;
using ToDoApp.Auth.Middlewares;
using ToDoApp.Auth.Services;
using ToDoApp.Auth.Services.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerTodoAppDb"));
});

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

builder.Services.AddControllers();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")
    .WithMethods("POST")
    .AllowAnyHeader()
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
