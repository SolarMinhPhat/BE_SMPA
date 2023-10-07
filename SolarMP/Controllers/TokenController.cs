﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SolarMP.DTOs;
using SolarMP.DTOs.JWT;
using SolarMP.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SolarMP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;

        private readonly solarMPContext _context;

        public TokenController(IConfiguration configuration, solarMPContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        /// <summary>
        /// làm ơn là hãy đăng nhập gòi mới test các api
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]

        [Route("Login_username_password")]
        public async Task<IActionResult> getToken(LoginDTO dto)
        {
            try
            {
                if(dto == null)
                {
                    return BadRequest();
                }
                else
                {
                    var acc = await this._context.Account.Where(x=>x.Username.Equals(dto.Username) && x.Password.Equals(dto.Password))
                        .FirstOrDefaultAsync();
                    if(acc == null)
                    {
                        throw new Exception("login fail");
                    }
                    else
                    {
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", acc.Accountid.ToString()),
                        new Claim("DisplayName", acc.Firstname),
                        new Claim("Username", acc.Username.ToString()),
                        new Claim("Email", acc.Email),
                        new Claim("Password", acc.Password)
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(30),
                        signingCredentials: signIn);

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));

                    }
                }
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Unauthorized();
        }
    }
}