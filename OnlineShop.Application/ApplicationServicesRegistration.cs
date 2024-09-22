using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace OnlineShop.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ApplicationCpnfiguration(this IServiceCollection Service,
        IConfiguration configuration)
    {
        Service.AddMediatR(Assembly.GetExecutingAssembly());
        Service.AddAutoMapper(Assembly.GetExecutingAssembly());

        Service.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            opt.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:Key"]))
            };
        });


        return Service;
    }
}