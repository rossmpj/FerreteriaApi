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
    public class EmpleadoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public EmpleadoController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/<ValuesController>
        /*[HttpGet]
        public async Task<IActionResult> GetEmpleado()
        {
            try
            {
                var list_colores = await _context.Empleados.Take(1).ToListAsync();

                return Ok(list_colores);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }*/

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            try
            {
                var list_empleados = await _context.Empleados.ToListAsync();
                return Ok(list_empleados);
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
