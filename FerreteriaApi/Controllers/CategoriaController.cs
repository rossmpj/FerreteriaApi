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
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CategoriaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var list_categorias = await _context.Categorias.Select(p => new
                {
                    IdCategoria = p.IdCategoria,
                    Nombre = p.Nombre,
                    Descripcion = p.Descripcion
                }).ToListAsync();
                return Ok(list_categorias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                else
                {
                    var query = await _context.Categorias
                     .Select(z => new
                     {
                         z.IdCategoria,
                         z.Nombre,
                         z.Descripcion
                     }).Where(s => s.IdCategoria == id).FirstAsync();
                    return Ok(query);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Categoria categoria)
        {
            try
            {
                _context.Add(categoria);
                await _context.SaveChangesAsync();
                return Ok(categoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                var registroCategoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                registroCategoria.Nombre = categoria.Nombre;
                registroCategoria.Descripcion = categoria.Descripcion;
                _context.Categorias.Update(registroCategoria);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La categoría se actualizó con éxito" });
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria == null)
                {
                    return NotFound();
                }
                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return Ok(new { message = "La categoría se eliminó con éxito" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
