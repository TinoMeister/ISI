using ISI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ISI.Services
{
    /// <summary>
    /// Service class for handling JWT (JSON Web Token) operations.
    /// </summary>
    public class JwtService
    {
        private const int Expiration = 8;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Constructor for JwtService class.
        /// </summary>
        /// <param name="configuration">The configuration to retrieve JWT-related settings.</param>
        public JwtService(IConfiguration configuration) => _configuration = configuration;

        /// <summary>
        /// Creates a JWT token for the given user.
        /// </summary>
        /// <param name="user">The user for whom the token is created.</param>
        /// <returns>An AuthResponse containing the JWT token and its expiration.</returns>
        public AuthResponse CreateToken(User user)
        {
            var expiration = DateTime.UtcNow.AddHours(Expiration);
            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );
            var tokenHandler = new JwtSecurityTokenHandler();

            return new AuthResponse
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expiration
            };
        }

        /// <summary>
        /// Creates a JWT token based on the provided claims, signing credentials, and expiration.
        /// </summary>
        /// <param name="claims">The claims to be included in the JWT.</param>
        /// <param name="credentials">The signing credentials for the JWT.</param>
        /// <param name="expiration">The expiration date and time of the JWT.</param>
        /// <returns>The created JWT token.</returns>
        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration) =>
            new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );

        /// <summary>
        /// Creates an array of claims for the provided user.
        /// </summary>
        /// <param name="user">The user for whom the claims are created.</param>
        /// <returns>An array of claims.</returns>
        private Claim[] CreateClaims(User user) =>
            new[] {
                // Subject of the JWT (the user)
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]!),
                // Unique identifier
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                // Time at which the JWT was issued
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

        /// <summary>
        /// Creates signing credentials based on the JWT key from configuration.
        /// </summary>
        /// <returns>The created signing credentials.</returns>
        private SigningCredentials CreateSigningCredentials() =>
            new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
                ),
                SecurityAlgorithms.HmacSha256
            );
    }
}
