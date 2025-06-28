    using System;
    using System.IdentityModel.Tokens.Jwt;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Webshop.DataContracts;
    using Webshop.Interfaces.Services;
    using Webshop.Models;

    namespace Webshop.Controllers
    {
        [AllowAnonymous]
        [Route("api/[controller]")]
        [ApiController]
        public class AuthController : ControllerBase
        {
            private readonly IUserService _userService;
            private readonly IEmailService _emailService;

            public AuthController(IUserService userService, IEmailService emailService)
            {
                _userService = userService;
                _emailService = emailService;
            }

            [HttpPost("login")]
            public ActionResult<string> Login([FromBody] LoginDto model)
            {
                var result = _userService.Login(model.Email, model.Password);

                if (result != null)
                {
                    var jwt = _userService.GetToken(result);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(jwt)
                    });
                }

                return Unauthorized();
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
            public IActionResult ForgotPassword([FromBody] string email)
            {
                try
                {
                    _userService.GeneratePasswordReset(email);

                    // Resetlink maken
                    var user = _userService.GetByEmail(email);
                    var resetLink = $"http://localhost:4200/reset-password?token={user.ResetToken}";

                    _emailService.Send(email, "Wachtwoord resetten", $"Klik op de volgende link om je wachtwoord te resetten:\n\n{resetLink}");

                    return Ok(new { message = "Resetlink is verstuurd" });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }
            
            [HttpPost("reset-password")]
            public IActionResult ResetPassword([FromBody] ResetPasswordDto dto)
            {
                try
                {
                    _userService.ResetPassword(dto.Token, dto.NewPassword);
                    return Ok(new { message = "Wachtwoord succesvol gereset" });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { message = ex.Message });
                }
            }


        }
    }