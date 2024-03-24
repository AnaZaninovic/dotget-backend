using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DotGetBackend.Application.Features.Professors.Dtos;
using DotGetBackend.Application.Features.Students.Dtos;
using DotGetBackend.Domain.Enums;
using Microsoft.IdentityModel.Tokens;

namespace TicTacToeBackend.Utils;

public static class TokenUtils
{
    public static string GenerateJwToken(StudentDto student, string jwtSecret)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, student.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, student.Email!),
            new Claim("uid", student.Id.ToString()),
            new Claim("role", UserRole.Student.ToString()),
        };

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            "DotGetBackend",
            "DotGetUsers",
            claims,
            expires: DateTime.UtcNow.AddMinutes(60 * 24),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
    
    public static async Task<string> GenerateJwToken(ProfessorDto professor, string jwtSecret)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, professor.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, professor.Email!),
            new Claim("uid", professor.Id.ToString()),
            new Claim("role", UserRole.Professor.ToString()),
        };

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            "DotGetBackend",
            "DotGetUsers",
            claims,
            expires: DateTime.UtcNow.AddMinutes(60 * 24),
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}