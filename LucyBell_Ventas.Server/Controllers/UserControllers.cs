using LucyBell_Ventas.Shared.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LucyBell_Ventas.Server.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserControllers : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;

        public UserControllers(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UserTokenDTO>> RegistrarUsuario([FromBody] UserInfoDTO userInfoDTO)
        {
            var usuario = new IdentityUser { UserName = userInfoDTO.Email, Email = userInfoDTO.Email };
            var res = await userManager.CreateAsync(usuario, userInfoDTO.Password);

            if (res.Succeeded)
            {
                return await ConstruirToken(userInfoDTO);
            }
            else
            {
                return BadRequest(res.Errors.First());
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserTokenDTO>> Login([FromBody] UserInfoDTO userInfoDTO)
        {
            var res = await signInManager.PasswordSignInAsync(userInfoDTO.Email,
                                                              userInfoDTO.Password,
                                                              isPersistent: false,
                                                              lockoutOnFailure: false);

            if (res.Succeeded)
            {
                return await ConstruirToken(userInfoDTO);
            }
            else
            {
                return BadRequest("Login incorrecto");
            }

        }

        private async Task<UserTokenDTO> ConstruirToken(UserInfoDTO userInfoDTO)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userInfoDTO.Email),
                new Claim(ClaimTypes.Email, userInfoDTO.Email),
                new Claim("otro", "cualquier cosa")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwtkey"]!));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddMonths(1);

            var token = new JwtSecurityToken
                            (
                                issuer: null,
                                audience: null,
                                claims: claims,
                                expires: expiracion,
                                signingCredentials: credenciales
                            );

            return new UserTokenDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiracion
            };
        }
    }
}