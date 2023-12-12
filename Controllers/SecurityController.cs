using ACCA_Backend.DataAccess.DTO;
using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ACCA_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        public readonly ISessionService _sessionService;
        public readonly IUsersService _usersService;
        public ILogger<SecurityController> _logger;

        public SecurityController(ISessionService securityService,
                                  ILogger<SecurityController> logger,
                                  IUsersService usersService)
        {
            _sessionService = securityService;
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        [Route("/auth")]
        public async Task<ActionResult<Sessions>> Auth()
        {
            try
            {
                var r = ((ClaimsIdentity)User.Identity).FindFirst("Id");
                var session = await _sessionService.GetSession(int.Parse(r.Value));

                return Ok(session);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("La sesión ha expirado");
            }
            catch (NullReferenceException)
            {
                return Unauthorized("La sesion ha expirado");
            }
            catch (Exception)
            {
                return Problem("Some error happened please contact Sys Admin");
            }
        }

        [HttpPost]
        [Route("/Login")]
        [AllowAnonymous]
        public async Task<ActionResult<Sessions>> Login([FromBody] LoginDTO user)
        {
            try
            {
                var userD = await _usersService.GetUserByEmailAndPassword(user.Email, user.Password);
                if (userD == null)
                {
                    return Unauthorized("El email/contraseña no coinciden");
                }

                var session = await _sessionService.SaveSession(userD);
                return Ok(session);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("El email/contraseña no coinciden");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ocurrió un problema durante el inicio de sesión");
                return Problem("An error occurred during login. Please contact the System Administrator");
            }
        }

    }
}