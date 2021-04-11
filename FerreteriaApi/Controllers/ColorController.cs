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
    public class ColorController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ColorController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<ColorController>
        [HttpGet]
        public async Task<IActionResult> GetColores()
        {
            try
            {
                var list_colores = await _context.Colores.Select(p => new
                {
                    IdColor = p.IdColor,
                    Nombre = p.Nombre
                }).ToListAsync();
                return Ok(list_colores);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        // GET: api/<ColorController>/5
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var color = await _context.Colores.FindAsync(id);
                if (color == null)
                {
                    return NotFound();
                }
                else
                {
                    var query = await _context.Colores
                     .Select(z => new
                     {
                         z.IdColor,
                         z.Nombre
                     }).Where(s => s.IdColor == id).FirstAsync();
                    return Ok(query);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<ColorController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Color color)
        {
            try
            {
                _context.Add(color);
                await _context.SaveChangesAsync();
                return Ok(color);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Color color)
        {
            try
            {
                var registroColor = await _context.Colores.FindAsync(id);
                if (color == null)
                {
                    return NotFound();
                }
                registroColor.Nombre = color.Nombre;
                _context.Colores.Update(registroColor);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El color se actualizó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var color = await _context.Colores.FindAsync(id);
                if (color == null)
                {
                    return NotFound();
                }
                _context.Colores.Remove(color);
                await _context.SaveChangesAsync();
                return Ok(new { message = "El color se eliminó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
