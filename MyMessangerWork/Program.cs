using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyMessagerWork.Application.Service;
using MyMessagerWork.Core.Abstract;
using MyMessagerWork.DataAcess;
using MyMessagerWork.DataAcess.Mapper;
using MyMessagerWork.DataAcess.Repositories;
using MyMessagerWork.Extensions;
using MyMessagerWork.Infrastructure;
using System.Text;
using static CSharpFunctionalExtensions.Result;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<MessagerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"),
        b => b.MigrationsAssembly("MyMessagerWork")));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
builder.Services.AddApiAuthentication(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(DomainProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
    HttpOnly = HttpOnlyPolicy.Always,
    Secure = CookieSecurePolicy.Always
});
// Ensure UseRouting is called before any middleware that deals with endpoints
app.UseHttpsRedirection();

app.UseRouting(); // Ensure this is called before use of Authorization and Authentication
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

