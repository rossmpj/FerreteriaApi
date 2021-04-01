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
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CategoriaController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var list_categorias = await _context.Categorias.Select(p => new
                {
                    IdCategoria = p.IdCategoria,
                    Nombre = p.Nombre
                }).ToListAsync();

                return Ok(list_categorias);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
