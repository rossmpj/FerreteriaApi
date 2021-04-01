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
                    /*.Join(
                        _context.Empleados,
                        ventas => ventas.IdEmpleado,
                        empleado => empleado.IdEmpleado,
                        (ventas, empleado) => new
                        { 
                            idVenta = ventas.IdVenta,
                            codigo = ventas.codigo,
                            fecha = ventas.Fecha,
                            cantidad = ventas.Cantidad,
                            cedula = ventas.Cedula,
                            idEmpleadoo = empleado.FullName,
                            idProducto = ventas.IdProducto,
                        }
                    )
                    .Join(
                         _context.Clientes,
                         ventas => ventas.cedula,
                         cliente => cliente.Cedula,
                         (ventas, cliente) => new
                         {
                             idVenta = ventas.idVenta,
                             codigo = ventas.codigo,
                             fecha = ventas.fecha,
                             cantidad = ventas.cantidad,
                             cedula = cliente.FullName,
                             idEmpleado = ventas.idEmpleadoo,
                             idProducto = ventas.idProducto,
                         }
                    )
                .Join(
                    _context.Productos,
                    ventas => ventas.idProducto,
                    producto => producto.IdProducto,
                    (ventas, producto) => new
                    {
                        idVenta = ventas.idVenta,
                        codigo = ventas.codigo,
                        fecha = ventas.fecha,
                        total = ventas.cantidad*producto.Precio,
                        cliente = ventas.cedula,
                        empleado = ventas.idEmpleado,
                        idProducto = ventas.idProducto,
                    }
                )*/
                    .Select(z => new { z.Fecha, z.codigo, z.Producto.Precio, clientN = z.Cliente.Nombre, clientA = z.Cliente.Apellido, empleadoN = z.Empleado.Nombre, empleadoA = z.Empleado.Apellido, z.Cantidad})
                .GroupBy(ventas => new { ventas.codigo, ventas.Fecha, ventas.clientN, ventas.clientA, ventas.empleadoN, ventas.empleadoA})
                .Select (e => new { e.Key.codigo, e.Key.Fecha, cliente = e.Key.clientN + " " + e.Key.clientA, empleado=e.Key.empleadoN+" "+e.Key.empleadoA, total = e.Sum(y => y.Cantidad*y.Precio)})
                .ToListAsync();

                /*var query = await _context.Ventas.FromSqlRaw("SELECT * FROM Ventas as p")
                    "join Clientes on p.Cedula = Clientes.Cedula "
                            "join e in _context.Empleados on v.IdEmpleado equals e.IdEmpleado"+
                            "join p in _context.Productos on v.IdProducto equals p.IdProducto"+
                            "group by p.codigo"
                            .ToListAsync();*/
                //select (o => new { g.Key, Sum = g.Sum(p => p.Producto.Precio * p.Cantidad)})
                //.ToListAsync();
                return Ok(query);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        // GET: api/<VentasController>
        /*[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

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
