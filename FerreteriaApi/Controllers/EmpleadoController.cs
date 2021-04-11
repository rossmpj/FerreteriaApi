using FerreteriaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public EmpleadoController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            try
            {
                var list_empleados = await _context.Empleados.Where(e => e.Estado == true).ToListAsync();
                return Ok(list_empleados);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var empleado = await _context.Empleados.FindAsync(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                else
                {
                    var query = await _context.Empleados
                     .Select(z => new
                     {
                         z.Cedula,
                         z.Nombre,
                         z.Apellido,
                         z.Correo,
                         z.IdEmpleado
                     }).Where(s => s.IdEmpleado == id).FirstAsync();
                    return Ok(query);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Empleado empleado)
        {
            try
            {
                empleado.Estado = true;
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return Ok(empleado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Empleado empleado)
        {
            try
            {
                var registroEmpleado = await _context.Empleados.FindAsync(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                registroEmpleado.Nombre = empleado.Nombre;
                registroEmpleado.Apellido = empleado.Apellido;
                registroEmpleado.Correo = empleado.Correo;
                registroEmpleado.Cedula = empleado.Cedula;
                _context.Empleados.Update(registroEmpleado);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El empleado se actualizó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var empleado = await _context.Empleados.FindAsync(id);
                if (empleado == null)
                {
                    return NotFound();
                }
                empleado.Estado = false;
                await _context.SaveChangesAsync();
                return Ok(new { message = "El empleado se eliminó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
