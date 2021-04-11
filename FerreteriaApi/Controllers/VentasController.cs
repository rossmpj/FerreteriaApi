using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FerreteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public VentasController(ApplicationDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetVentas()
        {
            try
            {
                var query = await _context.Ventas
                    .Select(z => new { 
                        z.Fecha, 
                        z.codigo, 
                        z.Producto.Precio, 
                        clientN = z.Cliente.Nombre, 
                        clientA = z.Cliente.Apellido, 
                        empleadoN = z.Empleado.Nombre, 
                        empleadoA = z.Empleado.Apellido, 
                        z.Cantidad
                    })
                    .GroupBy(ventas => new { 
                        ventas.codigo, 
                        ventas.Fecha, 
                        ventas.clientN, 
                        ventas.clientA, 
                        ventas.empleadoN, 
                        ventas.empleadoA
                    })
                    .Select (e => new { 
                        e.Key.codigo, 
                        e.Key.Fecha, 
                        cliente = e.Key.clientN + " " + e.Key.clientA, 
                        empleado = e.Key.empleadoN + " " + e.Key.empleadoA, 
                        total = e.Sum(y => y.Cantidad * y.Precio)
                    }
                ).ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("totalventas"), HttpGet]
        public async Task<IActionResult> GetTotalVentas()
        {
            try
            {
                var valortotal = await _context.Ventas
                    .Select(z => new
                    {
                        z.codigo,
                        z.Producto.Precio,
                        z.Cantidad
                    })
                    .GroupBy(ventas => new
                    {
                        ventas.codigo
                    })
                    .Select(e => new
                    {
                        total = e.Sum(y => y.Cantidad * y.Precio)
                    }
                )
                    .SumAsync(total => total.total);
                return Ok(valortotal);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET api/<VentasController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VentasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VentasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VentasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
