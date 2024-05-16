using bookHubServer.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bookHubServer.Tool;

public class TokenTool
{
    public static string GenerateToken(TokenClaim tokenClaim)
    {
        IConfiguration configuration;

        configuration = ConfigureTool.getConfig();

        //用非对称算法对私钥进行加密
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"])
        );


        Claim[] claims = new Claim[]
        {
               new Claim("userID",tokenClaim.userID.ToString()),
               new Claim("username",tokenClaim.username),
               new Claim("email",tokenClaim.email),
               new Claim("password",tokenClaim.password)
        };

        //生成数字签名
        SigningCredentials signingCredentials = new SigningCredentials(
            symmetricSecurityKey,
            SecurityAlgorithms.HmacSha256//签名算法
        );

        //生成token
        JwtSecurityToken token = new JwtSecurityToken(
            issuer: configuration["Authentication:Issuer"],
            audience: configuration["Authentication:Audience"],
            claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials
        );

        string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenStr;
    }

    public static TokenClaim ParseToken(string tokenStr)
    {
        IConfiguration configuration;

        configuration = ConfigureTool.getConfig();

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"]);

        tokenHandler.ValidateToken(tokenStr, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;

        var userID = int.Parse(jwtToken.Claims.First(x => x.Type == "userID").Value);
        var username = jwtToken.Claims.First(x => x.Type == "username").Value;
        var email = jwtToken.Claims.First(x => x.Type == "email").Value;
        var password = jwtToken.Claims.First(x => x.Type == "password").Value;

        return new TokenClaim
        {
            userID = userID,
            username = username,
            email = email,
            password = password
        };
    }
}
