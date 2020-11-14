using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Test.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Test.Utils
{
    public static class Authetication
    {
        public static string GenerateJsonWebToken(User user)
        {
            SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("B607148F7A90A019F177AED30507F624"));
            SigningCredentials credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
                new Claim("User" ,JsonSerializer.Serialize(user)),
            };

            JwtSecurityToken token = new JwtSecurityToken("Elearning", "Elearning", claims, DateTime.UtcNow, expires: DateTime.Now.AddMinutes(10), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        internal static TokenValidationParameters tokenValidationParams;

        public static void ConfigureJwtAuthentication(this IServiceCollection service)
        {
            SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("B607148F7A90A019F177AED30507F624"));
            SigningCredentials credentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
            tokenValidationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidIssuer = "Elearning",
                ValidateLifetime = true,
                ValidAudience = "Elearning",
                ValidateAudience = true,
                IssuerSigningKey = credentials.Key,
                ClockSkew = TimeSpan.FromDays(7),
            };

            service.AddAuthentication(options =>
           {
               options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = tokenValidationParams;
                options.RequireHttpsMetadata = true;
            });
        }
    }
}
