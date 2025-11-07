using AppCongreso.Data;
using AppCongreso.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppCongreso.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly CongresoDBContext _context;

        public UsuarioController(CongresoDBContext context)
        {
            _context = context;
        }

        [HttpPost("Registro")]
        public async Task<IActionResult> Registro([FromBody] Usuario u)
        {
            if (u == null)
                return BadRequest("El usuario no puede ser nulo");

            try
            {
                await _context.Usuarios.AddAsync(u);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    mensaje = "Usuario registrado correctamente",
                    usuario = u
                });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    mensaje = "Error al registrar el usuario",
                    error = ex.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            return Ok(usuarios);
        }
    }
}
