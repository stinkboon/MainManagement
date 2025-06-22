using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Webshop.DataContracts;
using Webshop.Interfaces.Services;

namespace Webshop.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("login")]
    public ActionResult<string> Login([FromBody] LoginDto model)
    {
        var result = _userService.Login(model.Email, model.Password);

        if (result != null)
        {
            var jwt = GetToken(result.Email);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(jwt)
            });
        }

        return Unauthorized();
    }

    private JwtSecurityToken GetToken(string email)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ditissupersecretzestienkarakters"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: "Webshop",
            audience: "WebshopUI",
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return token;
    }
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto dto)
    {
        try
        {
            var user = _userService.Register(dto.Email, dto.Password);
            return Ok(new 
            {
                message = "Registratie gelukt",
                email = user.Email 
            });

        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
    
    [HttpPost("forgot-password")]
    public IActionResult ForgotPassword([FromBody] ForgotPasswordDto dto)
    {
        var user = _userService.GetByEmail(dto.Email);

        if (user == null)
            return NotFound(new { message = "Gebruiker niet gevonden" });

        return Ok(new { message = "Reset link is verstuurd (niet echt)" });
    }


};