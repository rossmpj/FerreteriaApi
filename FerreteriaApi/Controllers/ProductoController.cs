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
    public class ProductoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public ProductoController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: api/<ProductoController>
        [HttpGet]
        public async Task<IActionResult> GetProductos()
        {
            try
            {
                var list_productos = await _context.Productos
                    .Join(
                        _context.Marcas,
                        marca => marca.IdMarca,
                        producto => producto.IdMarca,
                        (producto, marca) => new 
                        { 
                            idMarca = marca.Nombre,
                            idCategoria = producto.IdCategoria,
                            nombre = producto.Nombre,
                            stock = producto.Stock,
                            medida = producto.Medida,
                            precio = producto.Precio,
                            idColor = producto.IdColor,
                            idProducto = producto.IdProducto
                        }
                    )
                    .Join(
                         _context.Categorias,
                         producto => producto.idCategoria,
                         categoria => categoria.IdCategoria,
                         (producto, categoria) => new
                         {
                             idMarca = producto.idMarca,
                             nombre = producto.nombre,
                             stock = producto.stock,
                             medida = producto.medida,
                             idCategoria = categoria.Nombre,
                             precio = producto.precio,
                             idColor = producto.idColor,
                             idProducto = producto.idProducto
                         }
                    )
                    .Join(
                        _context.Colores,
                        producto => producto.idColor,
                        color => color.IdColor,
                        (producto, color) => new
                        {
                            idMarca = producto.idMarca,
                            nombre = producto.nombre,
                            stock = producto.stock,
                            medida = producto.medida,
                            idCategoria = producto.idCategoria,
                            precio = producto.precio,
                            idColor = color.Nombre,
                            idProducto = producto.idProducto
                        }
                    ).ToListAsync();
                return Ok(list_productos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("totalproductos"), HttpGet]
        public async Task<IActionResult> GetTotalProductos()
        {
            try
            {
                var list_productos = await _context.Productos.CountAsync();
                return Ok(list_productos);
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

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
