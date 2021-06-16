using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using API.DTOs;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    // [Authorize]
    public class IsletmeSahibiController: BaseController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public IsletmeSahibiController(DataContext context, ITokenService tokenService)
        {
            _tokenService = tokenService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<IsletmeDto>> Register(RegisterDto registerDto)
        {

            if (await UserExists(registerDto.Username)) return BadRequest("Username is taken!");

            using var hmac = new HMACSHA512();

            var user = new IsletmeSahibi
            {
                KullaniciAdi = registerDto.Username.ToLower(), 
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.EmlakIsletmesi.Add(user);
            await _context.SaveChangesAsync();

            return new IsletmeDto
            {
                Username = user.KullaniciAdi,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<IsletmeDto>> Login(LoginDto loginDto)
        {
            var user = await _context.EmlakIsletmesi.SingleOrDefaultAsync(x => x.KullaniciAdi == loginDto.Username);

            if (user == null) return Unauthorized("Invalid Username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");
            }

            return new IsletmeDto
            {

                Username = user.KullaniciAdi,
                Token = _tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.EmlakIsletmesi.AnyAsync(x => x.KullaniciAdi == username.ToLower());
        }

        
    }
}