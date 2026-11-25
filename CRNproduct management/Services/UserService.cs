using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using CRNproduct.Domain;
using CRNproduct_management.DTO;
using CRNproduct_management.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRNproduct_management.Services
{
    public class UserService : IUserService
    {
        private readonly IUser _user;
        private readonly IConfiguration _configuration;

        public UserService(IUser user, IConfiguration configuration)
        {
            _user = user;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTo?> LoginAsync(LoginDto dto)
        {
            var user = await _user.GetByEmailAsync(dto.Email);

            if (user == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(
                dto.Password,
                user.PasswordHash
            );

            if (!isValid)
                return null;

            var jwtKey = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey!)
            );

            var credentials = new SigningCredentials(
                securityKey,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new[]
            {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Username),
        new Claim(ClaimTypes.Email, user.Email)
    };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["Jwt:ExpiryMinutes"])
                ),
                signingCredentials: credentials
            );

            var refreshToken = Convert.ToBase64String(
                System.Security.Cryptography.RandomNumberGenerator.GetBytes(64)
            );

            var refreshTokenEntity = new RefreshToken
            {
                UserId = user.Id,
                Token = refreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7)
            };

            await _user.AddRefreshTokenAsync(refreshTokenEntity);

            return new LoginResponseDTo
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                RefreshToken = refreshToken
            };
        }

        public Task<LoginResponseDTo?> RefreshTokenAsync(RefreshTokenRequDto dto)
        {
            throw new NotImplementedException();
        }







        // REGISTER
        public async Task<User> RegisterAsync(UserCreateDto dto)
            {
                var existingUser = await _user.GetByEmailAsync(dto.Email);

                if (existingUser != null)
                {
                    throw new Exception("Email already registered");
                }

                var user = new User
                {
                    Username = dto.Username,
                    Email = dto.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
                };

                return await _user.RegisterAsync(user);
            }

        // LOGIN

        
    }

}

