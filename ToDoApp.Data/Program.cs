using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using ToDoApp.Data.Data;
using ToDoApp.Data.Data.Abstract;
using ToDoApp.Data.Middlewares;
using ToDoApp.Data.Services;
using ToDoApp.Data.Services.Abstract;
using ToDoApp.Common.Security;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddDbContextPool<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerTodoAppDb"));
});

builder.Services.AddTransient<GlobalExceptionHandlerMiddleware>();
builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ISpecialityService, SpecialityService>();
builder.Services.AddTransient<IObjectiveService, ObjectiveService>();
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<ISpecialityRepository, SpecialityRepository>();
builder.Services.AddTransient<IObjectiveRepository, ObjectiveRepository>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                //var tokenBlackList = context.HttpContext.RequestServices.GetRequiredService<ITokenBlackList>();
                //var tokenParser = context.HttpContext.RequestServices.GetRequiredService<ITokenParser>();
                var bearer = context.HttpContext.Request.Headers["Authorization"];

                if (String.IsNullOrEmpty(bearer))
                {
                    bearer = context.Request.Query["access_token"];
                }

                //var token = tokenParser.GetBearerTokenFromAuthHeaderString(bearer);
                //if (tokenBlackList.TokenIsBlackListed(token).Result)
                //{
                //    context.Fail("Token has expired");
                //}
                return Task.CompletedTask;
            }
        };
    });
builder.Services.AddAuthorization();
builder.Services.AddControllers();

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => builder
    .WithOrigins("http://localhost:3000")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();
