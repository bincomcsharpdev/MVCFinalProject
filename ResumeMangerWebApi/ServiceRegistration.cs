using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ResumeMangerWebApi.Data.Repository.Interfaces;
using ResumeMangerWebApi.Data.Repository.Repository;
using ResumeMangerWebApi.Data;
using ResumeMangerWebApi.Implementation.Interfaces;
using ResumeMangerWebApi.Implementation.Services;
using System.Text;

namespace ResumeMangerWebApi
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITaxRepository, TaxRepository>()
                    .AddScoped<IPhotoRepository, PhotoRepository>()
                    .AddScoped<ITaxService, TaxService>()
                    .AddScoped<IPhotoService, PhotoService>()
                    .AddScoped<IUserRepository, UserRepository>()
                    .AddScoped<ITokenService, TokenService>()
                    .AddScoped<IUserService, UserService>()
                    .AddScoped<Calculator>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = configuration["JwtSettings:Issuer"],
                            ValidAudience = configuration["JwtSettings:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                        };
                    });
            return services;
        }
    }
}
