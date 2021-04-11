using FerreteriaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FerreteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ClienteController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            try
            {
                var list_clientes = await _context.Clientes.Where(e => e.Estado == true).ToListAsync();
                return Ok(list_clientes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                else
                {
                    var query = await _context.Clientes
                     .Select(z => new
                     {
                         z.Cedula,
                         z.Nombre,
                         z.Apellido,
                         z.Telefono
                     }).Where(s => s.Cedula == id).FirstAsync();
                    return Ok(query);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cliente cliente)
        {
            try
            {
                cliente.Estado = true;
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return Ok(cliente);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Cliente cliente)
        {
            try
            {
                if (id != cliente.Cedula)
                {
                    return NotFound();
                }
                _context.Update(cliente);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El cliente se actualizó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var cliente = await _context.Clientes.FindAsync(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                cliente.Estado = false;
                await _context.SaveChangesAsync();
                return Ok(new { message = "El cliente se eliminó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
