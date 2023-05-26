using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using T2203E_API.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using T2203E_API.Dtos;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace T2203E_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly T2203eApiContext _context;
        public AuthController(T2203eApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("/register")]
        public IActionResult Register(UserRegister user)
        {  
            var hashed = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Users.Add(new Entities.User { Email=user.Email,Name=user.Name,Password=hashed});
            _context.SaveChanges();
            return Ok(new UserData { Name=user.Name,Email=user.Email});
        }
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(UserLogin user)
        {

        }
    }
}
