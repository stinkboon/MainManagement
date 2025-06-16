using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Webshop.DataContracts;

namespace Webshop.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginDto model)
    {
        if (model.UserName == "dani" && model.Password == "qwertY!")
        {
            var jwt = GetToken(model.UserName);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt)
            });
        }

        return Unauthorized();
    }

    private JwtSecurityToken GetToken(string userName)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, userName)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("DitIsSuperSecretPlusZestienKarakters"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Webshop",
            audience: "WebshopUI",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return token;
    }
};