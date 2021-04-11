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
    public class MarcaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public MarcaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<MarcaController>
        [HttpGet]
        public async Task<IActionResult> GetMarcas()
        {
            try
            {
                var list_marcas = await _context.Marcas.Select(p => new
                {
                    IdMarca = p.IdMarca,
                    Nombre = p.Nombre
                }).ToListAsync();

                return Ok(list_marcas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<MarcaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var marca = await _context.Marcas.FindAsync(id);
                if (marca == null)
                {
                    return NotFound();
                }
                else
                {
                    var query = await _context.Marcas
                     .Select(z => new
                     {
                         z.IdMarca,
                         z.Nombre
                     }).Where(s => s.IdMarca == id).FirstAsync();
                    return Ok(query);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<MarcaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Marca marca)
        {
            try
            {
                _context.Add(marca);
                await _context.SaveChangesAsync();
                return Ok(marca);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<MarcaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Marca marca)
        {
            try
            {
                var registroMarca = await _context.Marcas.FindAsync(id);
                if (marca == null)
                {
                    return NotFound();
                }
                registroMarca.Nombre = marca.Nombre;
                _context.Marcas.Update(registroMarca);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La marca se actualizó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<MarcaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var marca = await _context.Marcas.FindAsync(id);
                if (marca == null)
                {
                    return NotFound();
                }
                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La marca se eliminó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
