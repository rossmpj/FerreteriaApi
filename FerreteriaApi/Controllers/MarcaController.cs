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
        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<MarcaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MarcaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MarcaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MarcaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
