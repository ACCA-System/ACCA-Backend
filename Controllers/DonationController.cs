using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ACCA_Backend.DataAccess.Services.Interfaces;
using ACCA_Backend.DataAccess.Entities;
using ACCA_Backend.DataAccess.DTO;


namespace ACCA_Backend.Controllers
{
    //  [Authorize]  // Puedes agregar o quitar el atributo [Authorize] según tus requisitos de autenticación
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class DonationMethodController : ControllerBase
    {
        public readonly IDonationTypeService _donationTypeService;
        readonly ILogger<DonationMethodController> _logger;

        public DonationMethodController(IDonationTypeService donationTypeService, ILogger<DonationMethodController> logger)
        {
            _donationTypeService = donationTypeService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/DonationMethod/{DonationType}")]
        public async Task<ActionResult<DonationType>> GetDonationMethod(int donationTypeId)
        {
            try
            {
                var donationMethod = await _donationTypeService.GetDonationTypeById(donationTypeId);

                if (donationMethod == null)
                {
                    return NotFound("Método de donación no encontrado");
                }

                return Ok(donationMethod);
            }
            catch (Exception)
            {
                return Problem("Ocurrió un error. Por favor, contacta al administrador del sistema");
            }
        }
        

        [HttpPost]
        [Route("/DonationMethod")]
        public async Task<ActionResult<DonationType>> PostDonationMethod(DonationType donationType)
        {
            try
            {
                var donationMethod = await _donationTypeService.AddDonationType(donationType);
                return Ok(donationMethod);
            }
            catch (Exception ex)
            {
                if (ex.InnerException?.Message?.ToLower().Contains("duplicate") == true)
                    return BadRequest("El método de donación ya ha sido registrado");
                else
                    return Problem("Ocurrió un error. Por favor, contacta al administrador del sistema");
            }
        }

        [HttpPut]
        [Route("/DonationMethod")]
        public async Task<ActionResult<DonationType>> UpdateDonationMethod(DonationType donationMethodDTO)
        {
            try
            {
                var donationMethod = await _donationTypeService.UpdateDonationType(donationMethodDTO);

                if (donationMethod == null)
                {
                    return BadRequest("El método de donación no existe");
                }

                return Ok(donationMethod);
            }
            catch (Exception)
            {
                return Problem("Ocurrió un error. Por favor, contacta al administrador del sistema");
            }
        }

        [HttpDelete]
        [Route("/DonationMethod/{donationMethodId}")]
        public async Task<ActionResult<DonationType>> DeleteDonationMethod(int donationMethodId)
        {
            try
            {
                var donationMethod = await _donationTypeService.GetDonationTypeById(donationMethodId);

                if (donationMethod == null)
                {
                    return BadRequest("El método de donación no existe");
                }

                return Ok(donationMethod);
            }
            catch (Exception)
            {
                return Problem("Ocurrió un error. Por favor, contacta al administrador del sistema");
            }
        }
    }
}