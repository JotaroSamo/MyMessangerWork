using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyMessagerWork.Application.Service;
using MyMessagerWork.Infrastructure;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyMessagerWork.Extensions
{
    public static class ApiExtensions
    {
        public static void AddApiAuthentication(
          this IServiceCollection services,
          IConfiguration configuration)
        {
            var jwtOptions = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions!.SecretKey))

        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["tasty-cookies"];

                return Task.CompletedTask;
            }
        };
    });
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddAuthorization(options =>
            {
                //options.AddPolicy("AdminPolicy", policy =>
                //    {

                //        policy.RequireClaim("Admin", "true");
                //    }
                //);

                //options.AddPolicy("UserPolicy", policy =>
                //{

                //    policy.RequireClaim("User", "true");
                //}
                //);
            });
    }
 }
}
