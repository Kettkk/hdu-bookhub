using bookHubServer.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace bookHubServer.Tool;

public class TokenTool
{
    public static string GenerateToken(User user)
    {
        IConfiguration configuration;

        configuration = ConfigureTool.getConfig();

        //用非对称算法对私钥进行加密
        SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Authentication:SecretKey"])
        );


        Claim[] claims = new Claim[]
        {
               new Claim("userID",user.userID.ToString()),
               new Claim("username",user.username),
               new Claim("email",user.email),
               new Claim("password",user.password)
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
}
