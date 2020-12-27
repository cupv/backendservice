using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using API.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace API.Utils
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

            JwtSecurityToken token = new JwtSecurityToken("Elearning", "Elearning", claims, DateTime.UtcNow, expires: DateTime.Now.AddDays(300), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string VerifyJsonWebToken(string token)
        {
            Claim info  = null;

            SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("B607148F7A90A019F177AED30507F624"));
            var handler = new JwtSecurityTokenHandler();
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = secret,
                ValidateLifetime = true,
                ValidIssuer = "Elearning",
                ValidateAudience = true,
                ValidAudience = "Elearning",
            };
            var claims = handler.ValidateToken(token, validations, out var tokenSecure);
            foreach (var claim in claims.Claims)
            {
                info = claim;
                break;
            }
            return info.ToString();
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
